using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DatVe
{
    public partial class QLGhe : Form
    {
        private int maGheDangChon = -1;
        private bool dangLoad = false;

        public QLGhe()
        {
            InitializeComponent();
        }

        // 1. TẢI DỮ LIỆU BAN ĐẦU (Form Load)
        private void QLGhe_Load(object sender, EventArgs e)
        {
            dangLoad = true;

            cbo_Loai.Items.Clear();
            cbo_Loai.Items.Add("Thường");
            cbo_Loai.Items.Add("VIP");
            cbo_Loai.Items.Add("Đôi");
            cbo_Loai.SelectedIndex = 0;

            cbo_TrangThai.Items.Clear();
            cbo_TrangThai.Items.Add("Hoạt động");
            cbo_TrangThai.Items.Add("Hỏng");
            cbo_TrangThai.SelectedIndex = 0;

            LoadComboBoxPhong();

            dangLoad = false;
            LoadDanhSachGhe();
        }

        private void LoadComboBoxPhong()
        {
            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string query = "SELECT PC_Ma, PC_Ten FROM PhongChieu ORDER BY PC_Ma ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm dòng "Tất cả phòng" (PC_Ma = 0) lên đầu danh sách
                    DataRow allRow = dt.NewRow();
                    allRow["PC_Ma"] = 0;
                    allRow["PC_Ten"] = "-- Tất cả phòng --";
                    dt.Rows.InsertAt(allRow, 0);

                    cbo_Phong.DataSource = dt;
                    cbo_Phong.DisplayMember = "PC_Ten";
                    cbo_Phong.ValueMember = "PC_Ma";
                    cbo_Phong.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhSachGhe(string tuKhoaTimKiem = "")
        {
            if (cbo_Phong.SelectedValue == null || cbo_Phong.SelectedValue is DataRowView)
                return;

            try
            {
                int maPhongChon = Convert.ToInt32(cbo_Phong.SelectedValue);
                bool timToanBoPhong = (maPhongChon == 0) || KiemTraTimXuyenPhong(tuKhoaTimKiem);

                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string query = @"
                        SELECT g.G_Ma, g.PC_Ma, p.PC_Ten, g.G_Hang, g.G_So, g.G_Loai, g.G_PhuThu, g.G_TrangThai 
                        FROM Ghe g
                        JOIN PhongChieu p ON g.PC_Ma = p.PC_Ma
                        WHERE 1=1";

                    if (!timToanBoPhong)
                    {
                        query += " AND g.PC_Ma = @PC_Ma";
                    }

                    if (!string.IsNullOrEmpty(tuKhoaTimKiem))
                    {
                        query += @" AND (
                            REPLACE(p.PC_Ten + g.G_Hang + CAST(g.G_So AS VARCHAR(10)), ' ', '') COLLATE Vietnamese_CI_AI LIKE @TuKhoaKhongCach
                            OR (g.G_Hang + CAST(g.G_So AS VARCHAR(10))) LIKE @TuKhoaKhongCach
                            OR p.PC_Ten COLLATE Vietnamese_CI_AI LIKE @TuKhoaGoc
                            OR g.G_Loai COLLATE Vietnamese_CI_AI LIKE @TuKhoaGoc
                            OR g.G_TrangThai COLLATE Vietnamese_CI_AI LIKE @TuKhoaGoc
                        )";
                    }

                    query += " ORDER BY p.PC_Ma ASC, g.G_Hang ASC, g.G_So ASC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!timToanBoPhong)
                        {
                            cmd.Parameters.AddWithValue("@PC_Ma", maPhongChon);
                        }
                        if (!string.IsNullOrEmpty(tuKhoaTimKiem))
                        {
                            string khongCach = "%" + tuKhoaTimKiem.Replace(" ", "") + "%";
                            cmd.Parameters.AddWithValue("@TuKhoaKhongCach", khongCach);
                            cmd.Parameters.AddWithValue("@TuKhoaGoc", "%" + tuKhoaTimKiem + "%");
                        }

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgv_DSGhe.DataSource = dt;

                        dgv_DSGhe.Columns["G_Ma"].HeaderText = "Mã Ghế";
                        dgv_DSGhe.Columns["PC_Ma"].Visible = false;
                        dgv_DSGhe.Columns["PC_Ten"].HeaderText = "Phòng";
                        dgv_DSGhe.Columns["G_Hang"].HeaderText = "Hàng";
                        dgv_DSGhe.Columns["G_So"].HeaderText = "Số Ghế";
                        dgv_DSGhe.Columns["G_Loai"].HeaderText = "Loại Ghế";
                        dgv_DSGhe.Columns["G_PhuThu"].HeaderText = "Phụ Thu (VNĐ)";
                        dgv_DSGhe.Columns["G_TrangThai"].HeaderText = "Trạng Thái";
                        dgv_DSGhe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbo_Phong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangLoad) return;
            maGheDangChon = -1;
            txtTimKiem.Clear();
            LoadDanhSachGhe();
        }

        // 2. CHỌN DÒNG TRÊN BẢNG
        private void dgv_DSGhe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_DSGhe.Rows[e.RowIndex];
                maGheDangChon = Convert.ToInt32(row.Cells["G_Ma"].Value);

                dangLoad = true;
                cbo_Phong.SelectedValue = Convert.ToInt32(row.Cells["PC_Ma"].Value);
                dangLoad = false;

                txt_Hang.Text = row.Cells["G_Hang"].Value.ToString();
                txt_So.Text = row.Cells["G_So"].Value.ToString();
                cbo_Loai.Text = row.Cells["G_Loai"].Value.ToString();
                cbo_TrangThai.Text = row.Cells["G_TrangThai"].Value.ToString();
            }
        }

        // HÀM PUBLIC STATIC TÁCH RIÊNG CHO CÁC MODULE KHÁC GỌI LẠI
        public static decimal TinhPhuThu(string loaiGhe)
        {
            if (loaiGhe == "VIP") return 10000;
            if (loaiGhe == "Đôi") return 20000;
            return 0;
        }

        public static void CapNhatSoLuongGhe(int maPhong, SqlConnection conn, SqlTransaction tran = null)
        {
            string sql = "UPDATE PhongChieu SET PC_SLGhe = (SELECT COUNT(*) FROM Ghe WHERE PC_Ma = @PC_Ma) WHERE PC_Ma = @PC_Ma";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@PC_Ma", maPhong);
                cmd.ExecuteNonQuery();
            }
        }

        public static int TaoHangGhe(int maPhong, char hangBD, char hangKT, int soBD, int soKT, string loaiGhe, string trangThai)
        {
            decimal phuThu = TinhPhuThu(loaiGhe);
            int soGheDaThem = 0;

            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            using (SqlTransaction tran = conn.BeginTransaction())
            {
                try
                {
                    for (char h = hangBD; h <= hangKT; h++)
                    {
                        for (int s = soBD; s <= soKT; s++)
                        {
                            string checkSql = "SELECT COUNT(*) FROM Ghe WHERE PC_Ma = @PC_Ma AND G_Hang = @Hang AND G_So = @So";
                            using (SqlCommand cmdCheck = new SqlCommand(checkSql, conn, tran))
                            {
                                cmdCheck.Parameters.AddWithValue("@PC_Ma", maPhong);
                                cmdCheck.Parameters.AddWithValue("@Hang", h.ToString());
                                cmdCheck.Parameters.AddWithValue("@So", s);

                                if ((int)cmdCheck.ExecuteScalar() == 0)
                                {
                                    string insertSql = @"INSERT INTO Ghe (PC_Ma, G_Hang, G_So, G_Loai, G_PhuThu, G_TrangThai)
                                                         VALUES (@PC_Ma, @Hang, @So, @Loai, @PhuThu, @TrangThai)";
                                    using (SqlCommand cmd = new SqlCommand(insertSql, conn, tran))
                                    {
                                        cmd.Parameters.AddWithValue("@PC_Ma", maPhong);
                                        cmd.Parameters.AddWithValue("@Hang", h.ToString());
                                        cmd.Parameters.AddWithValue("@So", s);
                                        cmd.Parameters.AddWithValue("@Loai", loaiGhe);
                                        cmd.Parameters.AddWithValue("@PhuThu", phuThu);
                                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                                        cmd.ExecuteNonQuery();
                                        soGheDaThem++;
                                    }
                                }
                            }
                        }
                    }

                    CapNhatSoLuongGhe(maPhong, conn, tran);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            return soGheDaThem;
        }

        // 3. THÊM GHẾ
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (cbo_Phong.SelectedValue == null || Convert.ToInt32(cbo_Phong.SelectedValue) == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng chiếu cụ thể (không chọn 'Tất cả phòng') để thêm ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = Convert.ToInt32(cbo_Phong.SelectedValue);
            string hangInput = txt_Hang.Text.Trim().ToUpper();
            string soInput = txt_So.Text.Trim();
            string loaiGhe = cbo_Loai.Text;
            string trangThai = cbo_TrangThai.Text;

            if (string.IsNullOrEmpty(hangInput) || string.IsNullOrEmpty(soInput))
            {
                MessageBox.Show("Vui lòng nhập Hàng (VD: A hoặc A-E) và Số ghế (VD: 1 hoặc 1-10)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            char hangBD, hangKT;
            if (hangInput.Contains("-"))
            {
                string[] parts = hangInput.Split('-');
                if (parts.Length != 2 || parts[0].Length != 1 || parts[1].Length != 1 || parts[0][0] > parts[1][0])
                {
                    MessageBox.Show("Dải hàng không hợp lệ! Ví dụ đúng: A-E", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hangBD = parts[0][0];
                hangKT = parts[1][0];
            }
            else
            {
                if (hangInput.Length != 1 || !char.IsLetter(hangInput[0]))
                {
                    MessageBox.Show("Hàng ghế phải là 1 chữ cái (VD: A, B, C)!", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hangBD = hangKT = hangInput[0];
            }

            int soBD, soKT;
            if (soInput.Contains("-"))
            {
                string[] parts = soInput.Split('-');
                if (parts.Length != 2 || !int.TryParse(parts[0], out soBD) || !int.TryParse(parts[1], out soKT) || soBD <= 0 || soKT < soBD)
                {
                    MessageBox.Show("Dải số không hợp lệ! Ví dụ đúng: 1-10", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                if (!int.TryParse(soInput, out soBD) || soBD <= 0)
                {
                    MessageBox.Show("Số ghế phải là số nguyên dương!", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                soKT = soBD;
            }

            try
            {
                int soGheDaThem = TaoHangGhe(maPhong, hangBD, hangKT, soBD, soKT, loaiGhe, trangThai);
                if (soGheDaThem > 0)
                {
                    MessageBox.Show($"Đã thêm thành công {soGheDaThem} ghế vào {cbo_Phong.Text}!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DatLaiForm(giuPhongDangChon: true);
                }
                else
                {
                    MessageBox.Show("Các vị trí ghế này đã tồn tại trong phòng rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. SỬA GHẾ
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (maGheDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn một ghế trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiGheMoi = cbo_Loai.Text;
            decimal phuThuMoi = TinhPhuThu(loaiGheMoi);
            string trangThaiMoi = cbo_TrangThai.Text;

            try
            {
                int soVeDaCapNhatGia = 0;

                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        string updateGheSql = @"UPDATE Ghe 
                                                SET G_Loai = @Loai, G_PhuThu = @PhuThu, G_TrangThai = @TrangThai 
                                                WHERE G_Ma = @G_Ma";
                        using (SqlCommand cmd = new SqlCommand(updateGheSql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Loai", loaiGheMoi);
                            cmd.Parameters.AddWithValue("@PhuThu", phuThuMoi);
                            cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                            cmd.Parameters.AddWithValue("@G_Ma", maGheDangChon);
                            cmd.ExecuteNonQuery();
                        }

                        string updateVeGiaSql = @"
                            UPDATE v
                            SET v.Ve_Gia = sc.SC_GiaVe + CAST(@PhuThuMoi AS INT)
                            FROM Ve v
                            JOIN SuatChieu sc ON v.SC_Ma = sc.SC_Ma
                            WHERE v.G_Ma = @G_Ma
                              AND v.Ve_TrangThai NOT IN (N'Đã đặt', N'Đã hủy')";

                        using (SqlCommand cmdVe = new SqlCommand(updateVeGiaSql, conn, tran))
                        {
                            cmdVe.Parameters.AddWithValue("@PhuThuMoi", phuThuMoi);
                            cmdVe.Parameters.AddWithValue("@G_Ma", maGheDangChon);
                            soVeDaCapNhatGia = cmdVe.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }

                string thongBao = "Cập nhật thông tin ghế thành công!";
                if (soVeDaCapNhatGia > 0)
                {
                    thongBao += $"\nĐã tự động đồng bộ lại giá vé (Ve_Gia) cho {soVeDaCapNhatGia} vé chưa bán thuộc ghế này!";
                }

                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string tuKhoaHienTai = txtTimKiem.Text.Trim();
                LoadDanhSachGhe(tuKhoaHienTai);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa ghế: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. XÓA GHẾ
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (maGheDangChon == -1)
            {
                MessageBox.Show("Vui lòng chọn ghế cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = Convert.ToInt32(cbo_Phong.SelectedValue);
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa ghế {txt_Hang.Text}{txt_So.Text} không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string checkVeSql = "SELECT COUNT(*) FROM Ve WHERE G_Ma = @G_Ma";
                    using (SqlCommand cmdCheck = new SqlCommand(checkVeSql, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@G_Ma", maGheDangChon);
                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Không thể xóa ghế này vì đã có dữ liệu đặt vé! Hãy chuyển trạng thái ghế sang 'Hỏng'.",
                                            "Chặn xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string deleteSql = "DELETE FROM Ghe WHERE G_Ma = @G_Ma";
                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@G_Ma", maGheDangChon);
                        cmd.ExecuteNonQuery();
                    }

                    CapNhatSoLuongGhe(maPhong, conn);
                }

                MessageBox.Show("Đã xóa ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatLaiForm(giuPhongDangChon: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. ĐẶT LẠI
        private void btn_DatLai_Click(object sender, EventArgs e)
        {
            DatLaiForm(giuPhongDangChon: false);
        }

        private void DatLaiForm(bool giuPhongDangChon)
        {
            maGheDangChon = -1;
            txt_Hang.Clear();
            txt_So.Clear();
            cbo_Loai.SelectedIndex = 0;
            txtTimKiem.Clear();
            cbo_TrangThai.SelectedIndex = 0;

            if (!giuPhongDangChon)
            {
                dangLoad = true;
                cbo_Phong.SelectedIndex = 0; // Quay về "-- Tất cả phòng --"
                dangLoad = false;
            }

            txt_Hang.Focus();
            LoadDanhSachGhe();
        }

        // 7. TÌM KIẾM NHANH
        private bool KiemTraTimXuyenPhong(string tuKhoa)
        {
            string k = tuKhoa.ToLower();
            return k.Contains("phong") || k.Contains("phòng");
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            LoadDanhSachGhe(tuKhoa);
        }
    }
}