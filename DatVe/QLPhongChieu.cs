using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DatVe
{
    public partial class QLPhongChieu : Form
    {
        private bool dangChonDong = false;

        public QLPhongChieu()
        {
            InitializeComponent();
        }

        // 1. TẢI DANH SÁCH (Form Load)
        private void QLPhongChieu_Load(object sender, EventArgs e)
        {
            txt_MaPhong.ReadOnly = true;
            txt_SoGhe.ReadOnly = true;
            txt_SoGhe.Text = "0";

            // Nạp danh sách Loại phòng vào cbo_LoaiPhong
            cbo_LoaiPhong.Items.Clear();
            cbo_LoaiPhong.Items.Add("2D");
            cbo_LoaiPhong.Items.Add("3D");
            cbo_LoaiPhong.Items.Add("IMAX");
            cbo_LoaiPhong.Items.Add("4DX");
            cbo_LoaiPhong.SelectedIndex = 0;

            dangChonDong = true;
            cbo_TrangThai.Items.Clear();
            cbo_TrangThai.Items.Add("Tất cả");
            cbo_TrangThai.Items.Add("Hoạt động");
            cbo_TrangThai.Items.Add("Bảo trì");
            cbo_TrangThai.Items.Add("Ngừng hoạt động");
            cbo_TrangThai.SelectedIndex = 0;
            dangChonDong = false;

            LoadDanhSachPhong();
        }

        private void LoadDanhSachPhong(string dieuKienWhere = "")
        {
            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string query = "SELECT PC_Ma, PC_Ten, PC_SLGhe, PC_LoaiPhong, PC_TrangThai FROM PhongChieu " + dieuKienWhere;
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_DSPhong.DataSource = dt;

                    dgv_DSPhong.Columns["PC_Ma"].HeaderText = "Mã Phòng";
                    dgv_DSPhong.Columns["PC_Ten"].HeaderText = "Tên Phòng";
                    dgv_DSPhong.Columns["PC_SLGhe"].HeaderText = "Số Lượng Ghế";
                    dgv_DSPhong.Columns["PC_LoaiPhong"].HeaderText = "Loại Phòng";
                    dgv_DSPhong.Columns["PC_TrangThai"].HeaderText = "Trạng Thái";
                    dgv_DSPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Lọc phòng tự động khi đổi Trạng thái
        private void cbo_TrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangChonDong) return;

            string trangThai = cbo_TrangThai.Text;
            if (trangThai == "Tất cả" || string.IsNullOrEmpty(trangThai))
            {
                LoadDanhSachPhong();
            }
            else
            {
                LoadDanhSachPhong($"WHERE PC_TrangThai = N'{trangThai}'");
            }
        }

        // 2. XEM CHI TIẾT KHI CHỌN DÒNG TRÊN BẢNG
        private void dgv_DSPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dangChonDong = true;

                DataGridViewRow row = dgv_DSPhong.Rows[e.RowIndex];
                txt_MaPhong.Text = row.Cells["PC_Ma"].Value.ToString();
                txt_TenPhong.Text = row.Cells["PC_Ten"].Value.ToString();
                txt_SoGhe.Text = row.Cells["PC_SLGhe"].Value.ToString();

                string loaiPhong = row.Cells["PC_LoaiPhong"].Value?.ToString() ?? "2D";
                if (!cbo_LoaiPhong.Items.Contains(loaiPhong) && !string.IsNullOrEmpty(loaiPhong))
                {
                    cbo_LoaiPhong.Items.Add(loaiPhong);
                }
                cbo_LoaiPhong.Text = loaiPhong;

                cbo_TrangThai.Text = row.Cells["PC_TrangThai"].Value.ToString();

                txt_MaPhong.Enabled = false;
                dangChonDong = false;
            }
        }

        // 3. THÊM PHÒNG
        private void btn_Them_Click(object sender, EventArgs e)
        {
            string tenPhong = txt_TenPhong.Text.Trim();
            string loaiPhong = cbo_LoaiPhong.Text;
            string trangThai = cbo_TrangThai.Text == "Tất cả" ? "Hoạt động" : cbo_TrangThai.Text;

            if (string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Vui lòng nhập tên phòng chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenPhong.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string checkSql = "SELECT COUNT(*) FROM PhongChieu WHERE PC_Ten = @Ten";
                    using (SqlCommand cmdCheck = new SqlCommand(checkSql, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@Ten", tenPhong);
                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Tên phòng này đã tồn tại! Vui lòng đặt tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertSql = @"INSERT INTO PhongChieu (PC_Ten, PC_SLGhe, PC_LoaiPhong, PC_TrangThai) 
                                         VALUES (@Ten, 0, @Loai, @TrangThai)";
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenPhong);
                        cmd.Parameters.AddWithValue("@Loai", loaiPhong);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thêm phòng chiếu thành công! (Số ghế mặc định là 0, sẽ tự cập nhật khi thiết lập ghế)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatLaiForm();

                DialogResult moGhe = MessageBox.Show("Bạn có muốn chuyển sang thiết lập ghế cho phòng vừa tạo ngay không?",
                                     "Thiết lập ghế", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (moGhe == DialogResult.Yes)
                {
                    QLGhe frmGhe = new QLGhe();
                    frmGhe.ShowDialog();
                    LoadDanhSachPhong();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 4. SỬA PHÒNG
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng trên bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbo_TrangThai.Text == "Tất cả")
            {
                MessageBox.Show("Vui lòng chọn một trạng thái cụ thể (Hoạt động / Bảo trì / Ngừng hoạt động)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = int.Parse(txt_MaPhong.Text);
            string tenPhong = txt_TenPhong.Text.Trim();
            string loaiPhong = cbo_LoaiPhong.Text;
            string trangThai = cbo_TrangThai.Text;

            if (string.IsNullOrEmpty(tenPhong))
            {
                MessageBox.Show("Tên phòng không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string checkSql = "SELECT COUNT(*) FROM PhongChieu WHERE PC_Ten = @Ten AND PC_Ma <> @Ma";
                    using (SqlCommand cmdCheck = new SqlCommand(checkSql, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@Ten", tenPhong);
                        cmdCheck.Parameters.AddWithValue("@Ma", maPhong);
                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Tên phòng bị trùng với phòng khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string updateSql = @"UPDATE PhongChieu 
                                         SET PC_Ten = @Ten, PC_LoaiPhong = @Loai, PC_TrangThai = @TrangThai 
                                         WHERE PC_Ma = @Ma";
                    using (SqlCommand cmd = new SqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ten", tenPhong);
                        cmd.Parameters.AddWithValue("@Loai", loaiPhong);
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.Parameters.AddWithValue("@Ma", maPhong);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatLaiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. XÓA PHÒNG
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhong = int.Parse(txt_MaPhong.Text);

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng '{txt_TenPhong.Text}' không?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string checkRangBuoc = @"
                        SELECT 
                            (SELECT COUNT(*) FROM Ghe WHERE PC_Ma = @Ma) + 
                            (SELECT COUNT(*) FROM SuatChieu WHERE PC_Ma = @Ma)";

                    using (SqlCommand cmdCheck = new SqlCommand(checkRangBuoc, conn))
                    {
                        cmdCheck.Parameters.AddWithValue("@Ma", maPhong);
                        if ((int)cmdCheck.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Không thể xóa! Phòng này đã được thiết lập ghế ngồi hoặc đang có lịch suất chiếu.",
                                            "Chặn xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    string deleteSql = "DELETE FROM PhongChieu WHERE PC_Ma = @Ma";
                    using (SqlCommand cmd = new SqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ma", maPhong);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa phòng chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DatLaiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. ĐẶT LẠI
        private void btn_DatLai_Click(object sender, EventArgs e)
        {
            DatLaiForm();
        }

        private void DatLaiForm()
        {
            dangChonDong = true;
            txt_MaPhong.Clear();
            txt_TenPhong.Clear();
            txt_SoGhe.Text = "0";
            cbo_LoaiPhong.SelectedIndex = 0;
            cbo_TrangThai.SelectedIndex = 0;
            dangChonDong = false;

            txt_MaPhong.Enabled = true;
            txt_TenPhong.Focus();

            LoadDanhSachPhong();
        }

        // 7. KIỂM TRA PHÒNG TRỐNG THEO NGÀY GIỜ
        private void btn_KiemTra_Click(object sender, EventArgs e)
        {
            DateTime ngayChieu = dtp_NgayKiemTra.Value.Date;
            TimeSpan gioBD = dtp_GioBatDau.Value.TimeOfDay;
            TimeSpan gioKT = dtp_GioKetThuc.Value.TimeOfDay;

            if (gioBD >= gioKT)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn giờ bắt đầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string query = @"
                        SELECT PC_Ma, PC_Ten, PC_SLGhe, PC_LoaiPhong, PC_TrangThai 
                        FROM PhongChieu pc
                        WHERE pc.PC_TrangThai = N'Hoạt động'
                          AND NOT EXISTS (
                              SELECT 1 FROM SuatChieu sc
                              WHERE sc.PC_Ma = pc.PC_Ma
                                AND sc.SC_NgayChieu = @NgayChieu
                                AND sc.SC_GioBatDau < @GioKetThuc
                                AND sc.SC_GioKetThuc > @GioBatDau
                          )";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngayChieu;
                        cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBD;
                        cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = gioKT;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgv_DSPhong.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không có phòng nào trống trong khung giờ này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra phòng trống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}