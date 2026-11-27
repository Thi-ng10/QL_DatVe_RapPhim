using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace DatVe
{
    public partial class FrmDatVe : Form
    {
        // ===== Các control cần kéo trong Designer (đặt đúng tên) =====
        // cb_Phim (ComboBox), dgv_SuatChieu (DataGridView), pn_SoDoGhe (Panel, AutoScroll = true),
        // lst_GheChon (ListBox), lb_TongTien (Label),
        // txt_SDT (TextBox), btn_TimKhach (Button), txt_TenKhach (TextBox),
        // cb_LoaiKhach (ComboBox), cb_PhuongThuc (ComboBox),
        // btn_ThanhToan (Button), btn_Huy (Button)

        // Ghế mà phiên làm việc này đang giữ
        private class GheDangGiu
        {
            public int GMa;
            public int VeMa;
            public string TenGhe = "";
            public string Loai = "";
            public int GiaGoc;   // giá suất chiếu + phụ thu, chưa giảm
        }

        // Thông tin một ghế trên sơ đồ (gắn vào Tag của nút)
        private class GheTrenMap
        {
            public int GMa;
            public string Hang = "";
            public int So;
            public string Loai = "";
            public int PhuThu;
            public string TrangThaiGhe = "";
            public int? VeMa;
            public string? TrangThaiVe;
        }

        // Dùng để báo vé đã hết hạn giữ khi thanh toán
        private sealed class HetHanGiuException : Exception { }

        private readonly List<GheDangGiu> gheDangGiu = new();
        private readonly System.Windows.Forms.Timer tmLamMoi = new();
        private readonly ToolTip tip = new();
        private int scMa = 0;        // suất chiếu đang chọn
        private int giaSuat = 0;     // giá cơ bản của suất chiếu đang chọn
        private bool dangNap = false; // chặn sự kiện khi đang nạp dữ liệu

        public FrmDatVe()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (không cần double-click control trong Designer)
            Load += FrmDatVe_Load;
            FormClosing += FrmDatVe_FormClosing;
            cb_Phim.SelectedIndexChanged += cb_Phim_SelectedIndexChanged;
            dgv_SuatChieu.SelectionChanged += dgv_SuatChieu_SelectionChanged;
            btn_TimKhach.Click += btn_TimKhach_Click;
            txt_SDT.TextChanged += txt_SDT_TextChanged;
            cb_LoaiKhach.SelectedIndexChanged += cb_LoaiKhach_SelectedIndexChanged;
            btn_ThanhToan.Click += btn_ThanhToan_Click;
            btn_Huy.Click += btn_Huy_Click;

            tmLamMoi.Interval = 10000; // làm mới sơ đồ ghế mỗi 10 giây
            tmLamMoi.Tick += tmLamMoi_Tick;
        }

        // =====================================================
        // KHỞI TẠO
        // =====================================================
        private void FrmDatVe_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi();

            cb_Phim.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_LoaiKhach.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_PhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            pn_SoDoGhe.AutoScroll = true;

            cb_LoaiKhach.Items.AddRange(QuyDinhDatVe.GiamGia.Keys.ToArray());
            cb_LoaiKhach.SelectedIndex = 0;
            cb_PhuongThuc.Items.AddRange(QuyDinhDatVe.PhuongThuc);
            cb_PhuongThuc.SelectedIndex = 0;

            TaiPhim();
            CapNhatDanhSachChon();
            tmLamMoi.Start();
        }

        private void CauHinhLuoi()
        {
            dgv_SuatChieu.ReadOnly = true;
            dgv_SuatChieu.AllowUserToAddRows = false;
            dgv_SuatChieu.AllowUserToDeleteRows = false;
            dgv_SuatChieu.MultiSelect = false;
            dgv_SuatChieu.RowHeadersVisible = false;
            dgv_SuatChieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_SuatChieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmDatVe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            tmLamMoi.Stop();
            try
            {
                HuyGiuTatCa(false); // đóng form mà chưa thanh toán thì trả ghế về Trống
            }
            catch (SqlException)
            {
                // bỏ qua: vé còn lại sẽ tự bị xóa khi hết hạn giữ
            }
            tmLamMoi.Dispose();
            tip.Dispose();
        }

        // =====================================================
        // 4.5.1 CHỌN PHIM, SUẤT CHIẾU, SƠ ĐỒ GHẾ
        // =====================================================
        private void TaiPhim()
        {
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var da = new SqlDataAdapter("SELECT P_Ma, P_Ten FROM Phim ORDER BY P_Ten", conn);
                var dt = new DataTable();
                da.Fill(dt);

                dangNap = true;
                cb_Phim.DataSource = dt;
                cb_Phim.DisplayMember = "P_Ten";
                cb_Phim.ValueMember = "P_Ma";
                cb_Phim.SelectedIndex = -1;
                dangNap = false;
            }
            catch (SqlException ex)
            {
                dangNap = false;
                HienLoi(ex);
            }
        }

        private void cb_Phim_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (dangNap || cb_Phim.SelectedValue is not int pMa) return;

            HuyGiuTatCa(true);   // đổi phim thì hủy ghế đang giữ của suất cũ
            scMa = 0;
            TaiSuatChieu(pMa);
            TaiSoDoGhe();
        }

        private void TaiSuatChieu(int pMa)
        {
            const string sql = @"
                SELECT sc.SC_Ma,
                       sc.SC_NgayChieu AS NgayChieu,
                       CONVERT(varchar(5), sc.SC_GioBatDau, 108) AS GioBatDau,
                       CONVERT(varchar(5), sc.SC_GioKetThuc, 108) AS GioKetThuc,
                       pc.PC_Ten AS PhongChieu,
                       sc.SC_GiaVe AS GiaVe
                FROM SuatChieu sc
                JOIN PhongChieu pc ON pc.PC_Ma = sc.PC_Ma
                WHERE sc.P_Ma = @p AND sc.SC_NgayChieu >= CAST(GETDATE() AS date)
                ORDER BY sc.SC_NgayChieu, sc.SC_GioBatDau";
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@p", pMa);
                var dt = new DataTable();
                da.Fill(dt);

                dangNap = true;
                dgv_SuatChieu.DataSource = dt;
                dgv_SuatChieu.Columns["SC_Ma"]!.Visible = false;
                dgv_SuatChieu.Columns["NgayChieu"]!.HeaderText = "Ngày chiếu";
                dgv_SuatChieu.Columns["NgayChieu"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_SuatChieu.Columns["GioBatDau"]!.HeaderText = "Giờ bắt đầu";
                dgv_SuatChieu.Columns["GioKetThuc"]!.HeaderText = "Giờ kết thúc";
                dgv_SuatChieu.Columns["PhongChieu"]!.HeaderText = "Phòng chiếu";
                dgv_SuatChieu.Columns["GiaVe"]!.HeaderText = "Giá vé";
                dgv_SuatChieu.Columns["GiaVe"]!.DefaultCellStyle.Format = "N0";
                dgv_SuatChieu.CurrentCell = null;   // chưa chọn suất nào
                dgv_SuatChieu.ClearSelection();
                dangNap = false;
            }
            catch (SqlException ex)
            {
                dangNap = false;
                HienLoi(ex);
            }
        }

        private void dgv_SuatChieu_SelectionChanged(object? sender, EventArgs e)
        {
            if (dangNap) return;
            DataGridViewRow? row = dgv_SuatChieu.CurrentRow;
            if (row == null) return;

            int scMoi = Convert.ToInt32(row.Cells["SC_Ma"].Value);
            if (scMoi == scMa) return;

            HuyGiuTatCa(true);   // đổi suất thì hủy ghế đang giữ của suất cũ
            scMa = scMoi;
            giaSuat = Convert.ToInt32(row.Cells["GiaVe"].Value);
            TaiSoDoGhe();
        }

        // Tải sơ đồ ghế: xóa vé hết hạn giữ rồi vẽ lại theo trạng thái
        private void TaiSoDoGhe(bool tuDong = false)
        {
            if (scMa == 0)
            {
                XoaSoDo();
                return;
            }

            const string sqlXoaHetHan = @"DELETE FROM Ve
                WHERE SC_Ma = @sc AND Ve_TrangThai = N'Đang giữ' AND Ve_HetHanGiu < GETDATE()";
            const string sqlSoDo = @"
                SELECT g.G_Ma, g.G_Hang, g.G_So, g.G_Loai, g.G_PhuThu, g.G_TrangThai,
                       v.Ve_Ma, v.Ve_TrangThai
                FROM SuatChieu sc
                JOIN Ghe g ON g.PC_Ma = sc.PC_Ma
                LEFT JOIN Ve v ON v.G_Ma = g.G_Ma AND v.SC_Ma = sc.SC_Ma AND v.Ve_TrangThai <> N'Đã hủy'
                WHERE sc.SC_Ma = @sc
                ORDER BY g.G_Hang, g.G_So";

            var ds = new List<GheTrenMap>();
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();

                using (var del = new SqlCommand(sqlXoaHetHan, conn))
                {
                    del.Parameters.AddWithValue("@sc", scMa);
                    del.ExecuteNonQuery();
                }

                using var cmd = new SqlCommand(sqlSoDo, conn);
                cmd.Parameters.AddWithValue("@sc", scMa);
                using SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    ds.Add(new GheTrenMap
                    {
                        GMa = rd.GetInt32(0),
                        Hang = rd.GetString(1),
                        So = rd.GetInt32(2),
                        Loai = rd.GetString(3),
                        PhuThu = (int)rd.GetDecimal(4),
                        TrangThaiGhe = rd.GetString(5),
                        VeMa = rd.IsDBNull(6) ? null : rd.GetInt32(6),
                        TrangThaiVe = rd.IsDBNull(7) ? null : rd.GetString(7)
                    });
                }
            }
            catch (SqlException ex)
            {
                if (!tuDong) HienLoi(ex);
                return;
            }

            // Ghế của mình mà không còn là "Đang giữ" trong CSDL nghĩa là đã hết hạn giữ
            var hetHan = gheDangGiu
                .Where(g => !ds.Any(x => x.VeMa == g.VeMa && x.TrangThaiVe == "Đang giữ"))
                .ToList();
            foreach (var g in hetHan) gheDangGiu.Remove(g);

            VeSoDo(ds);
            CapNhatDanhSachChon();

            if (hetHan.Count > 0)
            {
                tmLamMoi.Stop();
                MessageBox.Show(
                    "Ghế " + string.Join(", ", hetHan.Select(h => h.TenGhe)) +
                    " đã hết thời gian giữ, vui lòng chọn lại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tmLamMoi.Start();
            }
        }

        private void XoaSoDo()
        {
            while (pn_SoDoGhe.Controls.Count > 0)
                pn_SoDoGhe.Controls[0].Dispose();
        }

        private void VeSoDo(List<GheTrenMap> ds)
        {
            pn_SoDoGhe.SuspendLayout();
            XoaSoDo();

            int y = 10;
            int x = 40;
            string? hangTruoc = null;

            foreach (GheTrenMap g in ds)
            {
                if (g.Hang != hangTruoc)
                {
                    if (hangTruoc != null) y += 44;
                    hangTruoc = g.Hang;
                    x = 40;
                    pn_SoDoGhe.Controls.Add(new Label
                    {
                        Text = g.Hang,
                        Left = 10,
                        Top = y + 8,
                        AutoSize = true,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold)
                    });
                }

                int rong = g.Loai == "Đôi" ? 96 : 46;
                var btn = new Button
                {
                    Text = g.Hang + g.So,
                    Width = rong,
                    Height = 36,
                    Left = x,
                    Top = y,
                    Tag = g,
                    FlatStyle = FlatStyle.Flat,
                    UseVisualStyleBackColor = false
                };
                btn.FlatAppearance.BorderSize = g.Loai == "VIP" ? 2 : 1;
                btn.FlatAppearance.BorderColor = g.Loai == "VIP" ? Color.Goldenrod : Color.Gray;

                bool cuaToi = g.VeMa.HasValue && gheDangGiu.Any(h => h.VeMa == g.VeMa);
                if (g.TrangThaiGhe != "Hoạt động")
                {
                    btn.BackColor = Color.DimGray;      // ghế hỏng
                    btn.Enabled = false;
                }
                else if (g.TrangThaiVe == "Đã đặt")
                {
                    btn.BackColor = Color.IndianRed;    // Đã bán
                }
                else if (cuaToi)
                {
                    btn.BackColor = Color.DeepSkyBlue;  // ghế mình đang giữ
                }
                else if (g.TrangThaiVe == "Đang giữ")
                {
                    btn.BackColor = Color.Orange;       // ghế người khác đang giữ
                }
                else
                {
                    btn.BackColor = Color.LightGreen;   // Trống
                }

                tip.SetToolTip(btn, g.Hang + g.So + " - " + g.Loai + " - phụ thu " + g.PhuThu.ToString("N0") + "đ");
                btn.Click += Ghe_Click;
                pn_SoDoGhe.Controls.Add(btn);

                x += rong + 6;
            }

            pn_SoDoGhe.ResumeLayout();
        }

        private void tmLamMoi_Tick(object? sender, EventArgs e)
        {
            if (scMa != 0) TaiSoDoGhe(true);
        }

        // =====================================================
        // 4.5.2 GIỮ GHẾ / BỎ GIỮ GHẾ
        // =====================================================
        private void Ghe_Click(object? sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not GheTrenMap g) return;
            if (scMa == 0)
            {
                ThongBao("Vui lòng chọn phim và suất chiếu.");
                return;
            }

            GheDangGiu? cuaToi = gheDangGiu.FirstOrDefault(x => x.GMa == g.GMa);
            if (cuaToi != null)
            {
                // Bấm lại ghế mình đang giữ: bỏ giữ, ghế về Trống
                try
                {
                    XoaVeDangGiu(new[] { cuaToi.VeMa });
                }
                catch (SqlException ex)
                {
                    HienLoi(ex);
                    return;
                }
                gheDangGiu.Remove(cuaToi);
            }
            else if (g.TrangThaiVe == "Đã đặt")
            {
                ThongBao("Ghế này đã bán.");
                return;
            }
            else if (g.TrangThaiVe == "Đang giữ")
            {
                ThongBao("Ghế này đang được giữ, không còn trống.");
                return;
            }
            else if (!GiuGhe(g))
            {
                TaiSoDoGhe();
                return;
            }

            TaiSoDoGhe();
        }

        private bool GiuGhe(GheTrenMap g)
        {
            int giaGoc = giaSuat + g.PhuThu;
            // Không dùng OUTPUT vì bảng Ve có trigger; lấy mã vé bằng SCOPE_IDENTITY()
            const string sql = @"
                INSERT INTO Ve (SC_Ma, G_Ma, Ve_Gia, Ve_TrangThai, Ve_HetHanGiu)
                VALUES (@sc, @g, @gia, N'Đang giữ', DATEADD(MINUTE, @phut, GETDATE()));
                SELECT CAST(SCOPE_IDENTITY() AS int);";
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sc", scMa);
                cmd.Parameters.AddWithValue("@g", g.GMa);
                cmd.Parameters.AddWithValue("@gia", giaGoc);
                cmd.Parameters.AddWithValue("@phut", QuyDinhDatVe.SoPhutGiu);
                int veMa = Convert.ToInt32(cmd.ExecuteScalar());

                gheDangGiu.Add(new GheDangGiu
                {
                    GMa = g.GMa,
                    VeMa = veMa,
                    TenGhe = g.Hang + g.So,
                    Loai = g.Loai,
                    GiaGoc = giaGoc
                });
                return true;
            }
            catch (SqlException ex) when (QuyDinhDatVe.LaLoiTrungKhoa(ex))
            {
                ThongBao("Ghế vừa có người chọn, vui lòng chọn ghế khác.");
                return false;
            }
            catch (SqlException ex)
            {
                HienLoi(ex); // gồm lỗi từ trigger TR_Ve_KiemTraPhong
                return false;
            }
        }

        private void XoaVeDangGiu(IEnumerable<int> dsVeMa)
        {
            using SqlConnection conn = DbKetNoi.MoKetNoi();
            foreach (int ve in dsVeMa)
            {
                using var cmd = new SqlCommand(
                    "DELETE FROM Ve WHERE Ve_Ma = @ve AND Ve_TrangThai = N'Đang giữ'", conn);
                cmd.Parameters.AddWithValue("@ve", ve);
                cmd.ExecuteNonQuery();
            }
        }

        // =====================================================
        // 4.5.4 HỦY GIỮ GHẾ
        // =====================================================
        private void HuyGiuTatCa(bool thongBao)
        {
            if (gheDangGiu.Count == 0) return;

            try
            {
                XoaVeDangGiu(gheDangGiu.Select(g => g.VeMa).ToList());
            }
            catch (SqlException ex)
            {
                HienLoi(ex);
                return;
            }
            gheDangGiu.Clear();
            CapNhatDanhSachChon();

            if (thongBao)
                ThongBao("Các ghế đang giữ đã được hủy.");
        }

        private void btn_Huy_Click(object? sender, EventArgs e)
        {
            if (gheDangGiu.Count == 0)
            {
                ThongBao("Chưa có ghế nào đang giữ.");
                return;
            }
            HuyGiuTatCa(false);
            TaiSoDoGhe();
        }

        // =====================================================
        // KHÁCH HÀNG VÀ DANH SÁCH GHẾ ĐÃ CHỌN
        // =====================================================
        private static bool SdtHopLe(string sdt)
        {
            return Regex.IsMatch(sdt, @"^0\d{9,10}$");
        }

        private void txt_SDT_TextChanged(object? sender, EventArgs e)
        {
            // Đổi số điện thoại thì coi như khách khác: mở lại ô nhập
            txt_TenKhach.ReadOnly = false;
            cb_LoaiKhach.Enabled = true;
        }

        private void btn_TimKhach_Click(object? sender, EventArgs e)
        {
            string sdt = txt_SDT.Text.Trim();
            if (!SdtHopLe(sdt))
            {
                ThongBao("Vui lòng nhập số điện thoại hợp lệ.");
                return;
            }

            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var cmd = new SqlCommand(
                    "SELECT TOP 1 KH_Ten, KH_LoaiKhach FROM KhachHang WHERE KH_SDT = @sdt ORDER BY KH_Ma", conn);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                using SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txt_TenKhach.Text = rd.GetString(0);
                    int vt = cb_LoaiKhach.Items.IndexOf(rd.GetString(1));
                    cb_LoaiKhach.SelectedIndex = vt >= 0 ? vt : 0;
                    txt_TenKhach.ReadOnly = true;
                    cb_LoaiKhach.Enabled = false;
                }
                else
                {
                    ThongBao("Khách chưa có trong hệ thống, vui lòng nhập tên và loại khách để thêm mới.");
                    txt_TenKhach.Focus();
                }
            }
            catch (SqlException ex)
            {
                HienLoi(ex);
            }
        }

        private void cb_LoaiKhach_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CapNhatDanhSachChon();
        }

        private string LoaiKhachHienTai()
        {
            return cb_LoaiKhach.SelectedItem?.ToString() ?? "Thường";
        }

        private void CapNhatDanhSachChon()
        {
            string loai = LoaiKhachHienTai();
            int tong = 0;

            lst_GheChon.Items.Clear();
            foreach (GheDangGiu g in gheDangGiu)
            {
                int gia = QuyDinhDatVe.TinhGia(g.GiaGoc, loai);
                tong += gia;
                lst_GheChon.Items.Add(g.TenGhe + " (" + g.Loai + ") - " + gia.ToString("N0") + "đ");
            }
            lb_TongTien.Text = "Tổng tiền: " + tong.ToString("N0") + "đ";
        }

        // =====================================================
        // 4.5.3 THANH TOÁN (TRONG MỘT SqlTransaction)
        // =====================================================
        private void btn_ThanhToan_Click(object? sender, EventArgs e)
        {
            if (gheDangGiu.Count == 0)
            {
                ThongBao("Vui lòng chọn ít nhất một ghế.");
                return;
            }

            string sdt = txt_SDT.Text.Trim();
            if (!SdtHopLe(sdt))
            {
                ThongBao("Vui lòng nhập số điện thoại hợp lệ.");
                return;
            }

            string ten = txt_TenKhach.Text.Trim();
            string loai = LoaiKhachHienTai();
            string phuongThuc = cb_PhuongThuc.Text.Trim();
            if (phuongThuc.Length == 0)
            {
                ThongBao("Vui lòng chọn phương thức thanh toán.");
                return;
            }

            using SqlConnection conn = DbKetNoi.MoKetNoi();
            using SqlTransaction tran = conn.BeginTransaction();
            try
            {
                // 1. Tìm khách theo số điện thoại, chưa có thì thêm mới
                int khMa;
                using (var cmdTim = new SqlCommand(
                    "SELECT TOP 1 KH_Ma, KH_LoaiKhach FROM KhachHang WHERE KH_SDT = @sdt ORDER BY KH_Ma", conn, tran))
                {
                    cmdTim.Parameters.AddWithValue("@sdt", sdt);
                    using SqlDataReader rd = cmdTim.ExecuteReader();
                    if (rd.Read())
                    {
                        khMa = rd.GetInt32(0);
                        loai = rd.GetString(1);   // loại khách lấy theo CSDL
                    }
                    else
                    {
                        khMa = 0;
                    }
                }

                if (khMa == 0)
                {
                    if (ten.Length == 0)
                    {
                        Rollback(tran);
                        ThongBao("Khách mới: vui lòng nhập tên khách.");
                        return;
                    }
                    using var cmdThem = new SqlCommand(@"
                        INSERT INTO KhachHang (KH_Ten, KH_SDT, KH_LoaiKhach) VALUES (@ten, @sdt, @loai);
                        SELECT CAST(SCOPE_IDENTITY() AS int);", conn, tran);
                    cmdThem.Parameters.AddWithValue("@ten", ten);
                    cmdThem.Parameters.AddWithValue("@sdt", sdt);
                    cmdThem.Parameters.AddWithValue("@loai", loai);
                    khMa = Convert.ToInt32(cmdThem.ExecuteScalar());
                }

                // 2. Tạo hóa đơn (tổng tiền cập nhật sau)
                int hdMa;
                using (var cmdHd = new SqlCommand(@"
                    INSERT INTO HoaDon (KH_Ma, HD_TongTien, HD_NgayLap, HD_PhuongThucThanhToan)
                    VALUES (@kh, 0, GETDATE(), @pt);
                    SELECT CAST(SCOPE_IDENTITY() AS int);", conn, tran))
                {
                    cmdHd.Parameters.AddWithValue("@kh", khMa);
                    cmdHd.Parameters.AddWithValue("@pt", phuongThuc);
                    hdMa = Convert.ToInt32(cmdHd.ExecuteScalar());
                }

                // 3. Từng vé: tính lại giá theo loại khách, chuyển Đã đặt, thêm chi tiết hóa đơn
                int giam = QuyDinhDatVe.GiamTheoLoai(loai);
                foreach (GheDangGiu g in gheDangGiu)
                {
                    // Chỉ cập nhật được nếu vé vẫn đang giữ và chưa hết hạn
                    using (var cmdVe = new SqlCommand(@"
                        UPDATE v
                        SET v.Ve_Gia = CAST(ROUND((sc.SC_GiaVe + gh.G_PhuThu) * (100 - @giam) / 100.0, 0) AS int),
                            v.Ve_TrangThai = N'Đã đặt',
                            v.Ve_HetHanGiu = NULL
                        FROM Ve v
                        JOIN SuatChieu sc ON sc.SC_Ma = v.SC_Ma
                        JOIN Ghe gh ON gh.G_Ma = v.G_Ma
                        WHERE v.Ve_Ma = @ve AND v.Ve_TrangThai = N'Đang giữ' AND v.Ve_HetHanGiu >= GETDATE()",
                        conn, tran))
                    {
                        cmdVe.Parameters.AddWithValue("@giam", giam);
                        cmdVe.Parameters.AddWithValue("@ve", g.VeMa);
                        if (cmdVe.ExecuteNonQuery() != 1)
                            throw new HetHanGiuException();
                    }

                    // CTHD_DonGia sao chép từ Ve_Gia
                    using var cmdCt = new SqlCommand(@"
                        INSERT INTO ChiTietHoaDon (HD_Ma, Ve_Ma, CTHD_DonGia)
                        SELECT @hd, Ve_Ma, Ve_Gia FROM Ve WHERE Ve_Ma = @ve", conn, tran);
                    cmdCt.Parameters.AddWithValue("@hd", hdMa);
                    cmdCt.Parameters.AddWithValue("@ve", g.VeMa);
                    cmdCt.ExecuteNonQuery();
                }

                // 4. Cập nhật tổng tiền hóa đơn
                decimal tong;
                using (var cmdTong = new SqlCommand(@"
                    UPDATE HoaDon
                    SET HD_TongTien = (SELECT ISNULL(SUM(CTHD_DonGia), 0) FROM ChiTietHoaDon WHERE HD_Ma = @hd)
                    WHERE HD_Ma = @hd;
                    SELECT HD_TongTien FROM HoaDon WHERE HD_Ma = @hd;", conn, tran))
                {
                    cmdTong.Parameters.AddWithValue("@hd", hdMa);
                    tong = Convert.ToDecimal(cmdTong.ExecuteScalar());
                }

                tran.Commit();

                MessageBox.Show(
                    "Thanh toán thành công!\nMã hóa đơn: " + hdMa + "\nTổng tiền: " + tong.ToString("N0") + "đ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gheDangGiu.Clear();
                CapNhatDanhSachChon();
                LamMoiKhach();
                TaiSoDoGhe();
            }
            catch (HetHanGiuException)
            {
                Rollback(tran);
                ThongBao("Thời gian giữ ghế đã hết, vui lòng chọn lại ghế.");
                HuyGiuTatCa(false);   // hết hạn thì bắt chọn lại toàn bộ
                TaiSoDoGhe();
            }
            catch (SqlException ex)
            {
                Rollback(tran);
                MessageBox.Show("Thanh toán thất bại, dữ liệu đã được hoàn tác.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TaiSoDoGhe();
            }
        }

        private static void Rollback(SqlTransaction tran)
        {
            try
            {
                tran.Rollback();
            }
            catch (InvalidOperationException)
            {
                // giao dịch đã bị hủy (ví dụ trigger đã ROLLBACK)
            }
        }

        private void LamMoiKhach()
        {
            txt_SDT.Clear();
            txt_TenKhach.Clear();
            txt_TenKhach.ReadOnly = false;
            cb_LoaiKhach.Enabled = true;
            cb_LoaiKhach.SelectedIndex = 0;
            cb_PhuongThuc.SelectedIndex = 0;
        }

        // =====================================================
        // TIỆN ÍCH
        // =====================================================
        private static void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void HienLoi(Exception ex)
        {
            MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}