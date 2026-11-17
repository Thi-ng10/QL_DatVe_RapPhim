using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DatVe
{
    public partial class QLPhim : Form
    {
        public QLPhim()
        {
            InitializeComponent();
        }

        private void QLPhim_Load(object sender, EventArgs e)
        {
            if (cbTT.Items.Count > 0)
                cbTT.SelectedIndex = 0;
            LoadDanhSachPhim();
        }
        private void LoadDanhSachPhim(string query = "", SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    if (string.IsNullOrEmpty(query))
                    {
                        query = @"SELECT P_Ma AS [Mã phim], 
                                         P_Ten AS [Tên phim], 
                                         P_TheLoai AS [Thể loại], 
                                         P_ThoiLuong AS [Thời lượng (phút)], 
                                         P_DaoDien AS [Đạo diễn], 
                                         P_DienVien AS [Diễn viên], 
                                         P_GioiHanTuoi AS [Giới hạn tuổi], 
                                         P_NgayKhoiChieu AS [Ngày khởi chiếu], 
                                         P_TrangThai AS [Trạng thái], 
                                         P_MoTa AS [Mô tả] 
                                  FROM Phim";
                    }
                    SqlCommand cmd = new SqlCommand(query, conn);
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPhim.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhim.Rows.Count - (dgvPhim.AllowUserToAddRows ? 1 : 0))
            {
                DataGridViewRow row = dgvPhim.Rows[e.RowIndex];
                txtMaPhim.Text = row.Cells["Mã phim"].Value?.ToString();
                txtTenPhim.Text = row.Cells["Tên phim"].Value?.ToString();
                txtTheLoai.Text = row.Cells["Thể loại"].Value?.ToString();
                txtThoiLuong.Text = row.Cells["Thời lượng (phút)"].Value?.ToString();
                txtDaoDien.Text = row.Cells["Đạo diễn"].Value?.ToString();
                txtDienVien.Text = row.Cells["Diễn viên"].Value?.ToString();
                txtGHTuoi.Text = row.Cells["Giới hạn tuổi"].Value?.ToString();

                if (row.Cells["Ngày khởi chiếu"].Value != DBNull.Value && row.Cells["Ngày khởi chiếu"].Value != null)
                {
                    dtpNgayKhoiChieu.Value = Convert.ToDateTime(row.Cells["Ngày khởi chiếu"].Value);
                }

                cbTT.Text = row.Cells["Trạng thái"].Value?.ToString();
                txtMoTa.Text = row.Cells["Mô tả"].Value?.ToString();
            }
        }
        private bool KiemTraDuLieu()
        {
            if (string.IsNullOrWhiteSpace(txtTenPhim.Text))
            {
                MessageBox.Show("Tên phim không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhim.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtThoiLuong.Text) && (!int.TryParse(txtThoiLuong.Text, out int thoiLuong) || thoiLuong <= 0))
            {
                MessageBox.Show("Thời lượng phim phải là số nguyên dương!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThoiLuong.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtGHTuoi.Text) && (!int.TryParse(txtGHTuoi.Text, out int gioiHanTuoi) || gioiHanTuoi < 0))
            {
                MessageBox.Show("Giới hạn tuổi phải là số nguyên không âm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGHTuoi.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string sql = @"INSERT INTO Phim (P_Ten, P_TheLoai, P_ThoiLuong, P_DaoDien, P_DienVien, P_GioiHanTuoi, P_NgayKhoiChieu, P_MoTa, P_TrangThai)
                                   VALUES (@Ten, @TheLoai, @ThoiLuong, @DaoDien, @DienVien, @GioiHanTuoi, @NgayKhoiChieu, @MoTa, @TrangThai)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Ten", txtTenPhim.Text.Trim());
                    cmd.Parameters.AddWithValue("@TheLoai", string.IsNullOrWhiteSpace(txtTheLoai.Text) ? DBNull.Value : txtTheLoai.Text.Trim());
                    cmd.Parameters.AddWithValue("@ThoiLuong", string.IsNullOrWhiteSpace(txtThoiLuong.Text) ? DBNull.Value : int.Parse(txtThoiLuong.Text));
                    cmd.Parameters.AddWithValue("@DaoDien", string.IsNullOrWhiteSpace(txtDaoDien.Text) ? DBNull.Value : txtDaoDien.Text.Trim());
                    cmd.Parameters.AddWithValue("@DienVien", string.IsNullOrWhiteSpace(txtDienVien.Text) ? DBNull.Value : txtDienVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiHanTuoi", string.IsNullOrWhiteSpace(txtGHTuoi.Text) ? DBNull.Value : int.Parse(txtGHTuoi.Text));
                    cmd.Parameters.AddWithValue("@NgayKhoiChieu", dtpNgayKhoiChieu.Value.Date);
                    cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(txtMoTa.Text) ? DBNull.Value : txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", cbTT.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm phim mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhim.Text))
            {
                MessageBox.Show("Vui lòng chọn phim cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!KiemTraDuLieu()) return;

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string sql = @"UPDATE Phim 
                                   SET P_Ten = @Ten, P_TheLoai = @TheLoai, P_ThoiLuong = @ThoiLuong, 
                                       P_DaoDien = @DaoDien, P_DienVien = @DienVien, P_GioiHanTuoi = @GioiHanTuoi, 
                                       P_NgayKhoiChieu = @NgayKhoiChieu, P_MoTa = @MoTa, P_TrangThai = @TrangThai
                                   WHERE P_Ma = @MaPhim";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaPhim", int.Parse(txtMaPhim.Text));
                    cmd.Parameters.AddWithValue("@Ten", txtTenPhim.Text.Trim());
                    cmd.Parameters.AddWithValue("@TheLoai", string.IsNullOrWhiteSpace(txtTheLoai.Text) ? DBNull.Value : txtTheLoai.Text.Trim());
                    cmd.Parameters.AddWithValue("@ThoiLuong", string.IsNullOrWhiteSpace(txtThoiLuong.Text) ? DBNull.Value : int.Parse(txtThoiLuong.Text));
                    cmd.Parameters.AddWithValue("@DaoDien", string.IsNullOrWhiteSpace(txtDaoDien.Text) ? DBNull.Value : txtDaoDien.Text.Trim());
                    cmd.Parameters.AddWithValue("@DienVien", string.IsNullOrWhiteSpace(txtDienVien.Text) ? DBNull.Value : txtDienVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@GioiHanTuoi", string.IsNullOrWhiteSpace(txtGHTuoi.Text) ? DBNull.Value : int.Parse(txtGHTuoi.Text));
                    cmd.Parameters.AddWithValue("@NgayKhoiChieu", dtpNgayKhoiChieu.Value.Date);
                    cmd.Parameters.AddWithValue("@MoTa", string.IsNullOrWhiteSpace(txtMoTa.Text) ? DBNull.Value : txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@TrangThai", cbTT.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLamMoi_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhim.Text))
            {
                MessageBox.Show("Vui lòng chọn phim cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhim = int.Parse(txtMaPhim.Text);

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string checkSql = "SELECT COUNT(*) FROM SuatChieu WHERE P_Ma = @MaPhim";
                    SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@MaPhim", maPhim);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Không thể xóa phim này vì đã có suất chiếu trong hệ thống!", "Chặn xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa phim này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string deleteSql = "DELETE FROM Phim WHERE P_Ma = @MaPhim";
                        SqlCommand delCmd = new SqlCommand(deleteSql, conn);
                        delCmd.Parameters.AddWithValue("@MaPhim", maPhim);
                        delCmd.ExecuteNonQuery();

                        MessageBox.Show("Xóa phim thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phim: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTKPhim_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTKPhim.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadDanhSachPhim();
                return;
            }

            string sql = @"SELECT P_Ma AS [Mã phim], P_Ten AS [Tên phim], P_TheLoai AS [Thể loại], 
                                  P_ThoiLuong AS [Thời lượng (phút)], P_DaoDien AS [Đạo diễn], 
                                  P_DienVien AS [Diễn viên], P_GioiHanTuoi AS [Giới hạn tuổi], 
                                  P_NgayKhoiChieu AS [Ngày khởi chiếu], P_TrangThai AS [Trạng thái], 
                                  P_MoTa AS [Mô tả] 
                           FROM Phim 
                           WHERE P_Ten LIKE @TuKhoa OR P_TheLoai LIKE @TuKhoa OR P_DaoDien LIKE @TuKhoa";

            SqlParameter[] p = { new SqlParameter("@TuKhoa", "%" + tuKhoa + "%") };
            LoadDanhSachPhim(sql, p);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPhim.Clear();
            txtTenPhim.Clear();
            txtTheLoai.Clear();
            txtThoiLuong.Clear();
            txtDaoDien.Clear();
            txtDienVien.Clear();
            txtGHTuoi.Clear();
            txtMoTa.Clear();
            txtTKPhim.Clear();
            dtpNgayKhoiChieu.Value = DateTime.Now;
            if (cbTT.Items.Count > 0)
                cbTT.SelectedIndex = 0;
            dgvPhim.ClearSelection();
            LoadDanhSachPhim();
        }
    }
}
