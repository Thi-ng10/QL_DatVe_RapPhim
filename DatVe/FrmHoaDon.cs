using System.Data;
using System.Drawing.Printing;
using System.Text;
using Microsoft.Data.SqlClient;

namespace DatVe
{
    public partial class FrmHoaDon : Form
    {
        // ===== Các control cần kéo trong Designer (đặt đúng tên) =====
        // Tìm kiếm: txt_TimKiem (TextBox), chk_LocNgay (CheckBox), dtp_TuNgay, dtp_DenNgay (DateTimePicker),
        //           btn_Tim (Button), btn_TaiLai (Button)
        // Danh sách: dgv_HoaDon (DataGridView), dgv_ChiTiet (DataGridView)
        // Thông tin: txt_HDMa, txt_TenKhach, txt_SDT, txt_NgayLap, txt_TongTien (TextBox, chỉ đọc),
        //            cb_PhuongThuc (ComboBox)
        // Nút: btn_Sua (Button), btn_In (Button)

        private bool dangNap = false;
        private readonly PrintDocument pd = new();

        public FrmHoaDon()
        {
            InitializeComponent();

            // Gắn sự kiện bằng code (không cần double-click control trong Designer)
            Load += FrmHoaDon_Load;
            dgv_HoaDon.SelectionChanged += dgv_HoaDon_SelectionChanged;
            btn_Tim.Click += btn_Tim_Click;
            btn_TaiLai.Click += btn_TaiLai_Click;
            btn_Sua.Click += btn_Sua_Click;
            btn_In.Click += btn_In_Click;
            pd.PrintPage += pd_PrintPage;
        }

        private void FrmHoaDon_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi(dgv_HoaDon);
            CauHinhLuoi(dgv_ChiTiet);

            // Khóa các ô chỉ để xem (kể cả HD_Ma)
            txt_HDMa.ReadOnly = true;
            txt_TenKhach.ReadOnly = true;
            txt_SDT.ReadOnly = true;
            txt_NgayLap.ReadOnly = true;
            txt_TongTien.ReadOnly = true;

            cb_PhuongThuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_PhuongThuc.Items.AddRange(QuyDinhDatVe.PhuongThuc);

            dtp_TuNgay.Value = DateTime.Today.AddDays(-30);
            dtp_DenNgay.Value = DateTime.Today;
            chk_LocNgay.Checked = false;

            TaiHoaDon(null, false);
        }

        private static void CauHinhLuoi(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =====================================================
        // TẢI DANH SÁCH VÀ TÌM KIẾM
        // =====================================================
        // chonHdMa: hóa đơn cần chọn lại sau khi tải; baoKhongThay: báo khi không có kết quả
        private void TaiHoaDon(int? chonHdMa, bool baoKhongThay)
        {
            var sql = new StringBuilder(@"
                SELECT hd.HD_Ma, kh.KH_Ten, kh.KH_SDT, hd.HD_NgayLap, hd.HD_TongTien, hd.HD_PhuongThucThanhToan
                FROM HoaDon hd
                JOIN KhachHang kh ON kh.KH_Ma = hd.KH_Ma
                WHERE 1 = 1");

            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = conn;

                string tuKhoa = txt_TimKiem.Text.Trim();
                if (tuKhoa.Length > 0)
                {
                    // Tìm theo mã hóa đơn (chính xác) hoặc số điện thoại (gần đúng)
                    sql.Append(" AND (CAST(hd.HD_Ma AS varchar(20)) = @k OR kh.KH_SDT LIKE @sdt)");
                    da.SelectCommand.Parameters.AddWithValue("@k", tuKhoa);
                    da.SelectCommand.Parameters.AddWithValue("@sdt", "%" + tuKhoa + "%");
                }

                if (chk_LocNgay.Checked)
                {
                    sql.Append(" AND hd.HD_NgayLap >= @tu AND hd.HD_NgayLap < DATEADD(DAY, 1, @den)");
                    da.SelectCommand.Parameters.AddWithValue("@tu", dtp_TuNgay.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@den", dtp_DenNgay.Value.Date);
                }

                sql.Append(" ORDER BY hd.HD_NgayLap DESC, hd.HD_Ma DESC");
                da.SelectCommand.CommandText = sql.ToString();

                var dt = new DataTable();
                da.Fill(dt);

                dangNap = true;
                dgv_HoaDon.DataSource = dt;
                dgv_HoaDon.Columns["HD_Ma"]!.HeaderText = "Mã HĐ";
                dgv_HoaDon.Columns["KH_Ten"]!.HeaderText = "Khách hàng";
                dgv_HoaDon.Columns["KH_SDT"]!.HeaderText = "Số điện thoại";
                dgv_HoaDon.Columns["HD_NgayLap"]!.HeaderText = "Ngày lập";
                dgv_HoaDon.Columns["HD_NgayLap"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgv_HoaDon.Columns["HD_TongTien"]!.HeaderText = "Tổng tiền";
                dgv_HoaDon.Columns["HD_TongTien"]!.DefaultCellStyle.Format = "N0";
                dgv_HoaDon.Columns["HD_PhuongThucThanhToan"]!.HeaderText = "Thanh toán";

                // Chọn lại hóa đơn trước đó (nếu có)
                if (chonHdMa.HasValue)
                {
                    foreach (DataGridViewRow r in dgv_HoaDon.Rows)
                    {
                        if (Convert.ToInt32(r.Cells["HD_Ma"].Value) == chonHdMa.Value)
                        {
                            dgv_HoaDon.CurrentCell = r.Cells["HD_Ma"];
                            break;
                        }
                    }
                }
                dangNap = false;

                HienChiTietDangChon();

                if (dt.Rows.Count == 0 && baoKhongThay)
                    MessageBox.Show("Không tìm thấy hóa đơn phù hợp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                dangNap = false;
                HienLoi(ex);
            }
        }

        private void btn_Tim_Click(object? sender, EventArgs e)
        {
            TaiHoaDon(null, true);
        }

        private void btn_TaiLai_Click(object? sender, EventArgs e)
        {
            txt_TimKiem.Clear();
            chk_LocNgay.Checked = false;
            TaiHoaDon(null, false);
        }

        // =====================================================
        // XEM CHI TIẾT
        // =====================================================
        private void dgv_HoaDon_SelectionChanged(object? sender, EventArgs e)
        {
            if (dangNap) return;
            HienChiTietDangChon();
        }

        private void HienChiTietDangChon()
        {
            DataGridViewRow? row = dgv_HoaDon.CurrentRow;
            if (row == null)
            {
                XoaChiTiet();
                return;
            }

            int hdMa = Convert.ToInt32(row.Cells["HD_Ma"].Value);
            txt_HDMa.Text = hdMa.ToString();
            txt_TenKhach.Text = row.Cells["KH_Ten"].Value?.ToString() ?? "";
            txt_SDT.Text = row.Cells["KH_SDT"].Value?.ToString() ?? "";
            txt_NgayLap.Text = Convert.ToDateTime(row.Cells["HD_NgayLap"].Value).ToString("dd/MM/yyyy HH:mm");
            txt_TongTien.Text = Convert.ToDecimal(row.Cells["HD_TongTien"].Value).ToString("N0") + "đ";

            string pt = row.Cells["HD_PhuongThucThanhToan"].Value?.ToString() ?? "";
            if (pt.Length > 0 && !cb_PhuongThuc.Items.Contains(pt))
                cb_PhuongThuc.Items.Add(pt);   // giá trị cũ không nằm trong danh sách chuẩn
            cb_PhuongThuc.SelectedIndex = pt.Length > 0 ? cb_PhuongThuc.Items.IndexOf(pt) : -1;

            const string sql = @"
                SELECT p.P_Ten AS Phim,
                       sc.SC_NgayChieu AS NgayChieu,
                       CONVERT(varchar(5), sc.SC_GioBatDau, 108) AS GioBatDau,
                       pc.PC_Ten AS PhongChieu,
                       g.G_Hang + CAST(g.G_So AS varchar(5)) AS Ghe,
                       ct.CTHD_DonGia AS DonGia
                FROM ChiTietHoaDon ct
                JOIN Ve v ON v.Ve_Ma = ct.Ve_Ma
                JOIN SuatChieu sc ON sc.SC_Ma = v.SC_Ma
                JOIN Phim p ON p.P_Ma = sc.P_Ma
                JOIN PhongChieu pc ON pc.PC_Ma = sc.PC_Ma
                JOIN Ghe g ON g.G_Ma = v.G_Ma
                WHERE ct.HD_Ma = @hd
                ORDER BY g.G_Hang, g.G_So";
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@hd", hdMa);
                var dt = new DataTable();
                da.Fill(dt);

                dgv_ChiTiet.DataSource = dt;
                dgv_ChiTiet.Columns["Phim"]!.HeaderText = "Phim";
                dgv_ChiTiet.Columns["NgayChieu"]!.HeaderText = "Ngày chiếu";
                dgv_ChiTiet.Columns["NgayChieu"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                dgv_ChiTiet.Columns["GioBatDau"]!.HeaderText = "Giờ chiếu";
                dgv_ChiTiet.Columns["PhongChieu"]!.HeaderText = "Phòng";
                dgv_ChiTiet.Columns["Ghe"]!.HeaderText = "Ghế";
                dgv_ChiTiet.Columns["DonGia"]!.HeaderText = "Đơn giá";
                dgv_ChiTiet.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
            }
            catch (SqlException ex)
            {
                HienLoi(ex);
            }
        }

        private void XoaChiTiet()
        {
            txt_HDMa.Clear();
            txt_TenKhach.Clear();
            txt_SDT.Clear();
            txt_NgayLap.Clear();
            txt_TongTien.Clear();
            cb_PhuongThuc.SelectedIndex = -1;
            dgv_ChiTiet.DataSource = null;
        }

        // =====================================================
        // SỬA (CHỈ PHƯƠNG THỨC THANH TOÁN)
        // =====================================================
        private void btn_Sua_Click(object? sender, EventArgs e)
        {
            if (dgv_HoaDon.CurrentRow == null || txt_HDMa.Text.Length == 0)
            {
                ThongBao("Vui lòng chọn hóa đơn.");
                return;
            }
            if (cb_PhuongThuc.SelectedItem == null)
            {
                ThongBao("Vui lòng chọn phương thức thanh toán.");
                return;
            }

            int hdMa = int.Parse(txt_HDMa.Text);
            try
            {
                using SqlConnection conn = DbKetNoi.MoKetNoi();
                using var cmd = new SqlCommand(
                    "UPDATE HoaDon SET HD_PhuongThucThanhToan = @pt WHERE HD_Ma = @hd", conn);
                cmd.Parameters.AddWithValue("@pt", cb_PhuongThuc.SelectedItem.ToString()!);
                cmd.Parameters.AddWithValue("@hd", hdMa);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                HienLoi(ex);
                return;
            }

            ThongBao("Đã cập nhật phương thức thanh toán.");
            TaiHoaDon(hdMa, false);
        }

        // =====================================================
        // IN HÓA ĐƠN
        // =====================================================
        private void btn_In_Click(object? sender, EventArgs e)
        {
            if (dgv_HoaDon.CurrentRow == null || txt_HDMa.Text.Length == 0)
            {
                ThongBao("Vui lòng chọn hóa đơn.");
                return;
            }

            using var xem = new PrintPreviewDialog
            {
                Document = pd,
                Width = 800,
                Height = 700
            };
            xem.ShowDialog();   // trong cửa sổ xem trước có nút In
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics!;
            using Font fTieuDe = new("Arial", 16, FontStyle.Bold);
            using Font fDam = new("Arial", 10, FontStyle.Bold);
            using Font fThuong = new("Arial", 10);
            using var phai = new StringFormat { Alignment = StringAlignment.Far };

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float rong = e.MarginBounds.Width;

            g.DrawString("RẠP CHIẾU PHIM", fTieuDe, Brushes.Black, x, y);
            y += 32;
            g.DrawString("HÓA ĐƠN BÁN VÉ", fDam, Brushes.Black, x, y);
            y += 30;

            g.DrawString("Mã hóa đơn: " + txt_HDMa.Text, fThuong, Brushes.Black, x, y); y += 20;
            g.DrawString("Ngày lập: " + txt_NgayLap.Text, fThuong, Brushes.Black, x, y); y += 20;
            g.DrawString("Khách hàng: " + txt_TenKhach.Text, fThuong, Brushes.Black, x, y); y += 20;
            g.DrawString("Số điện thoại: " + txt_SDT.Text, fThuong, Brushes.Black, x, y); y += 20;
            g.DrawString("Thanh toán: " + cb_PhuongThuc.Text, fThuong, Brushes.Black, x, y); y += 30;

            // Tiêu đề bảng vé
            g.DrawString("Phim", fDam, Brushes.Black, x, y);
            g.DrawString("Suất chiếu", fDam, Brushes.Black, x + 220, y);
            g.DrawString("Phòng", fDam, Brushes.Black, x + 380, y);
            g.DrawString("Ghế", fDam, Brushes.Black, x + 470, y);
            g.DrawString("Đơn giá", fDam, Brushes.Black, new RectangleF(x + rong - 120, y, 120, 20), phai);
            y += 22;
            g.DrawLine(Pens.Black, x, y, x + rong, y);
            y += 6;

            if (dgv_ChiTiet.DataSource is DataTable dt)
            {
                foreach (DataRow r in dt.Rows)
                {
                    string suat = Convert.ToDateTime(r["NgayChieu"]).ToString("dd/MM/yyyy") + " " + r["GioBatDau"];
                    g.DrawString(r["Phim"].ToString(), fThuong, Brushes.Black, new RectangleF(x, y, 215, 20));
                    g.DrawString(suat, fThuong, Brushes.Black, x + 220, y);
                    g.DrawString(r["PhongChieu"].ToString(), fThuong, Brushes.Black, x + 380, y);
                    g.DrawString(r["Ghe"].ToString(), fThuong, Brushes.Black, x + 470, y);
                    g.DrawString(Convert.ToDecimal(r["DonGia"]).ToString("N0") + "đ", fThuong, Brushes.Black,
                        new RectangleF(x + rong - 120, y, 120, 20), phai);
                    y += 22;
                }
            }

            g.DrawLine(Pens.Black, x, y, x + rong, y);
            y += 8;
            g.DrawString("Tổng tiền: " + txt_TongTien.Text, fDam, Brushes.Black,
                new RectangleF(x, y, rong, 22), phai);

            e.HasMorePages = false;
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