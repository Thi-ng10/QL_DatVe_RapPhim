using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QLDatVe
{
    public partial class FrmSuatChieu : Form
    {
        public FrmSuatChieu()
        {
            InitializeComponent();

            this.Load += FrmSuatChieu_Load;

            btn_Them.Click += btn_Them_Click;
            btn_Sua.Click += btn_Sua_Click;
            btn_Xoa.Click += btn_Xoa_Click;
            btn_TimKiem.Click += btn_TimKiem_Click;
            btn_LamMoi.Click += btn_LamMoi_Click;

            cbo_Phim.SelectedIndexChanged += cbo_Phim_SelectedIndexChanged;
            dtp_GioBD.ValueChanged += dtp_GioBD_ValueChanged;
            dgv_SuatChieu.CellClick += dgv_SuatChieu_CellClick;
        }

        private void FrmSuatChieu_Load(object sender, EventArgs e)
        {
            dtp_GioBD.Format = DateTimePickerFormat.Custom;
            dtp_GioBD.CustomFormat = "HH:mm";
            dtp_GioBD.ShowUpDown = true;

            txt_GioKT.ReadOnly = true;

            LoadPhim();
            LoadPhong();
            LoadSuatChieu();
        }

        private void LoadPhim()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"
                    SELECT P_Ma, P_Ten, P_ThoiLuong
                    FROM Phim
                    WHERE P_TrangThai = N'Đang chiếu'
                    ORDER BY P_Ten";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbo_Phim.DataSource = dt;
                cbo_Phim.DisplayMember = "P_Ten";
                cbo_Phim.ValueMember = "P_Ma";
                cbo_Phim.SelectedIndex = -1;
            }
        }

        private void LoadPhong()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"
                    SELECT PC_Ma, PC_Ten
                    FROM PhongChieu
                    WHERE PC_TrangThai = N'Hoạt động'
                    ORDER BY PC_Ma";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbo_PhongChieu.DataSource = dt;
                cbo_PhongChieu.DisplayMember = "PC_Ten";
                cbo_PhongChieu.ValueMember = "PC_Ma";
                cbo_PhongChieu.SelectedIndex = -1;
            }
        }

        private void LoadSuatChieu()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                // Lấy tất cả các suất chiếu, tuyệt đối không có điều kiện WHERE lọc mã nào cả
                string sql = @"
            SELECT
                SC.SC_Ma,
                SC.P_Ma,
                P.P_Ten,
                SC.PC_Ma,
                PC.PC_Ten,
                SC.SC_NgayChieu,
                SC.SC_GioBatDau,
                SC.SC_GioKetThuc,
                SC.SC_GiaVe
            FROM SuatChieu SC
            INNER JOIN Phim P ON SC.P_Ma = P.P_Ma
            INNER JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
            ORDER BY SC.SC_Ma DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_SuatChieu.DataSource = dt;
                dgv_SuatChieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_SuatChieu.ReadOnly = true;
                dgv_SuatChieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_SuatChieu.MultiSelect = false;

                // Ẩn các cột ID thừa
                if (dgv_SuatChieu.Columns["P_Ma"] != null) dgv_SuatChieu.Columns["P_Ma"].Visible = false;
                if (dgv_SuatChieu.Columns["PC_Ma"] != null) dgv_SuatChieu.Columns["PC_Ma"].Visible = false;

                // Đổi tên tiếng Việt cho dễ nhìn
                if (dgv_SuatChieu.Columns["SC_Ma"] != null) dgv_SuatChieu.Columns["SC_Ma"].HeaderText = "Mã suất";
                if (dgv_SuatChieu.Columns["P_Ten"] != null) dgv_SuatChieu.Columns["P_Ten"].HeaderText = "Tên phim";
                if (dgv_SuatChieu.Columns["PC_Ten"] != null) dgv_SuatChieu.Columns["PC_Ten"].HeaderText = "Phòng chiếu";
                if (dgv_SuatChieu.Columns["SC_NgayChieu"] != null) dgv_SuatChieu.Columns["SC_NgayChieu"].HeaderText = "Ngày chiếu";
                if (dgv_SuatChieu.Columns["SC_GioBatDau"] != null) dgv_SuatChieu.Columns["SC_GioBatDau"].HeaderText = "Giờ BĐ";
                if (dgv_SuatChieu.Columns["SC_GioKetThuc"] != null) dgv_SuatChieu.Columns["SC_GioKetThuc"].HeaderText = "Giờ KT";
                if (dgv_SuatChieu.Columns["SC_GiaVe"] != null) dgv_SuatChieu.Columns["SC_GiaVe"].HeaderText = "Giá vé";
            }
        }

        private void cbo_Phim_SelectedIndexChanged(object sender, EventArgs e)
        {
            TinhGioKetThuc();
        }

        private void dtp_GioBD_ValueChanged(object sender, EventArgs e)
        {
            TinhGioKetThuc();
        }

        private void TinhGioKetThuc()
        {
            if (cbo_Phim.SelectedIndex < 0 || cbo_Phim.SelectedItem == null)
                return;

            DataRowView row = cbo_Phim.SelectedItem as DataRowView;
            if (row == null)
                return;

            int thoiLuong = Convert.ToInt32(row["P_ThoiLuong"]);
            DateTime gioBatDau = dtp_GioBD.Value;
            DateTime gioKetThuc = gioBatDau.AddMinutes(thoiLuong);

            txt_GioKT.Text = gioKetThuc.ToString("HH:mm");
        }

        private bool KiemTraTrungLich(
        SqlConnection conn,
        SqlTransaction tran,
        int maPhong,
        DateTime ngay,
        TimeSpan gioBatDau,
        TimeSpan gioKetThuc,
        int? maSuatBoQua = null)
            {
            string sql = @"
        SELECT COUNT(*)
        FROM SuatChieu
        WHERE PC_Ma = @PC_Ma
          AND SC_NgayChieu = @NgayChieu
          AND SC_GioBatDau < @GioKetThuc 
          AND SC_GioKetThuc > @GioBatDau";

            if (maSuatBoQua.HasValue)
            {
                sql += " AND SC_Ma <> @SC_Ma";
            }

            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.Add("@PC_Ma", SqlDbType.Int).Value = maPhong;
                cmd.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngay.Date;
                cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBatDau;
                cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = gioKetThuc;

                if (maSuatBoQua.HasValue)
                {
                    cmd.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatBoQua.Value;
                }

                int soLuong = Convert.ToInt32(cmd.ExecuteScalar());
                return soLuong > 0; // Trả về true nếu bị trùng lịch
            }
        }

        private decimal TinhGiaVe(string maGhe, string loaiGhe, decimal giaCoBan)
        {
            Ghe ghe;

            switch (loaiGhe.Trim())
            {
                case "Thường":
                    ghe = new GheThuong(maGhe);
                    break;
                case "VIP":
                    ghe = new GheVip(maGhe);
                    break;
                case "Đôi":
                    ghe = new GheDoi(maGhe);
                    break;
                default:
                    throw new Exception("Loại ghế không hợp lệ!");
            }

            return ghe.TinhGia(giaCoBan);
        }

        private void dgv_SuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_SuatChieu.Rows[e.RowIndex];
                cbo_Phim.SelectedValue = row.Cells["P_Ma"].Value;
                cbo_PhongChieu.SelectedValue = row.Cells["PC_Ma"].Value;
                dtp_NgayChieu.Value = Convert.ToDateTime(row.Cells["SC_NgayChieu"].Value);

                TimeSpan gioBD = (TimeSpan)row.Cells["SC_GioBatDau"].Value;
                dtp_GioBD.Value = DateTime.Today.Add(gioBD);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (cbo_Phim.SelectedIndex < 0 || cbo_PhongChieu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Phim và Phòng chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhim = Convert.ToInt32(cbo_Phim.SelectedValue);
            int maPhong = Convert.ToInt32(cbo_PhongChieu.SelectedValue);
            DateTime ngayChieu = dtp_NgayChieu.Value.Date;
            TimeSpan gioBatDau = dtp_GioBD.Value.TimeOfDay;
            TimeSpan gioKetThuc = TimeSpan.Parse(txt_GioKT.Text);
            int giaCoBan = 70000;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                if (KiemTraTrungLich(conn, null, maPhong, ngayChieu, gioBatDau, gioKetThuc))
                {
                    MessageBox.Show("Phòng chiếu này đã có lịch chiếu trong khung giờ này!", "Lỗi trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string sqlInsertSC = @"
                    INSERT INTO SuatChieu (P_Ma, PC_Ma, SC_NgayChieu, SC_GioBatDau, SC_GioKetThuc, SC_GiaVe)
                    VALUES (@P_Ma, @PC_Ma, @NgayChieu, @GioBatDau, @GioKetThuc, @GiaVe);
                    SELECT SCOPE_IDENTITY();";

                    int maSuatChieuMoi;
                    using (SqlCommand cmdSC = new SqlCommand(sqlInsertSC, conn, tran))
                    {
                        cmdSC.Parameters.Add("@P_Ma", SqlDbType.Int).Value = maPhim;
                        cmdSC.Parameters.Add("@PC_Ma", SqlDbType.Int).Value = maPhong;
                        cmdSC.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngayChieu;
                        cmdSC.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBatDau;
                        cmdSC.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = gioKetThuc;
                        cmdSC.Parameters.Add("@GiaVe", SqlDbType.Int).Value = giaCoBan;

                        maSuatChieuMoi = Convert.ToInt32(cmdSC.ExecuteScalar());
                    }

                    string sqlGetGhe = "SELECT G_Ma, G_Loai FROM Ghe WHERE PC_Ma = @PC_Ma AND G_TrangThai = N'Hoạt động'";
                    DataTable dtGhe = new DataTable();
                    using (SqlCommand cmdGhe = new SqlCommand(sqlGetGhe, conn, tran))
                    {
                        cmdGhe.Parameters.Add("@PC_Ma", SqlDbType.Int).Value = maPhong;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmdGhe))
                        {
                            da.Fill(dtGhe);
                        }
                    }

                    if (dtGhe.Rows.Count == 0)
                    {
                        throw new Exception("Phòng chiếu này chưa có ghế hoạt động nào!");
                    }

                    foreach (DataRow row in dtGhe.Rows)
                    {
                        string maGhe = row["G_Ma"].ToString();
                        string loaiGhe = row["G_Loai"].ToString();

                        decimal giaVeDecimal = TinhGiaVe(maGhe, loaiGhe, giaCoBan);
                        int giaVe = Convert.ToInt32(giaVeDecimal);

                        string sqlInsertVe = @"
                            INSERT INTO Ve (SC_Ma, G_Ma, Ve_Gia, Ve_TrangThai)
                            VALUES (@SC_Ma, @G_Ma, @Ve_Gia, N'Đang giữ')";

                        using (SqlCommand cmdVe = new SqlCommand(sqlInsertVe, conn, tran))
                        {
                            cmdVe.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatChieuMoi;
                            cmdVe.Parameters.Add("@G_Ma", SqlDbType.Int).Value = Convert.ToInt32(maGhe);
                            cmdVe.Parameters.Add("@Ve_Gia", SqlDbType.Int).Value = giaVe;
                            cmdVe.Parameters.Add("@Ve_TrangThai", SqlDbType.NVarChar).Value = "Đang giữ";

                            cmdVe.ExecuteNonQuery();
                        }
                    }

                    tran.Commit();
                    MessageBox.Show("Thêm suất chiếu và tự động sinh vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuatChieu();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi thêm suất chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (dgv_SuatChieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu cần sửa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSuatChieu = Convert.ToInt32(dgv_SuatChieu.SelectedRows[0].Cells["SC_Ma"].Value);
            int maPhim = Convert.ToInt32(cbo_Phim.SelectedValue);
            int maPhong = Convert.ToInt32(cbo_PhongChieu.SelectedValue);
            DateTime ngayChieu = dtp_NgayChieu.Value.Date;
            TimeSpan gioBatDau = dtp_GioBD.Value.TimeOfDay;
            TimeSpan gioKetThuc = TimeSpan.Parse(txt_GioKT.Text);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                if (KiemTraTrungLich(conn, null, maPhong, ngayChieu, gioBatDau, gioKetThuc, maSuatChieu))
                {
                    MessageBox.Show("Phòng chiếu đã có lịch trùng vào khung giờ này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sql = @"
                    UPDATE SuatChieu 
                    SET P_Ma = @P_Ma, 
                        PC_Ma = @PC_Ma, 
                        SC_NgayChieu = @NgayChieu, 
                        SC_GioBatDau = @GioBatDau, 
                        SC_GioKetThuc = @SC_GioKetThuc
                    WHERE SC_Ma = @SC_Ma";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@P_Ma", SqlDbType.Int).Value = maPhim;
                    cmd.Parameters.Add("@PC_Ma", SqlDbType.Int).Value = maPhong;
                    cmd.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngayChieu;
                    cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBatDau;
                    cmd.Parameters.Add("@SC_GioKetThuc", SqlDbType.Time).Value = gioKetThuc;
                    cmd.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatChieu;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cập nhật suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSuatChieu();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_SuatChieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn suất chiếu cần xóa trên bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSuatChieu = Convert.ToInt32(dgv_SuatChieu.SelectedRows[0].Cells["SC_Ma"].Value);

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa suất chiếu này? (Các vé liên quan cũng sẽ bị xóa)",
                                              "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlTransaction tran = conn.BeginTransaction();

                    try
                    {
                        string sqlDelCTHD = "DELETE FROM ChiTietHoaDon WHERE Ve_Ma IN (SELECT Ve_Ma FROM Ve WHERE SC_Ma = @SC_Ma)";
                        using (SqlCommand cmdCTHD = new SqlCommand(sqlDelCTHD, conn, tran))
                        {
                            cmdCTHD.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatChieu;
                            cmdCTHD.ExecuteNonQuery();
                        }

                        string sqlDelVe = "DELETE FROM Ve WHERE SC_Ma = @SC_Ma";
                        using (SqlCommand cmdVe = new SqlCommand(sqlDelVe, conn, tran))
                        {
                            cmdVe.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatChieu;
                            cmdVe.ExecuteNonQuery();
                        }

                        string sqlDelSC = "DELETE FROM SuatChieu WHERE SC_Ma = @SC_Ma";
                        using (SqlCommand cmdSC = new SqlCommand(sqlDelSC, conn, tran))
                        {
                            cmdSC.Parameters.Add("@SC_Ma", SqlDbType.Int).Value = maSuatChieu;
                            cmdSC.ExecuteNonQuery();
                        }

                        tran.Commit();
                        MessageBox.Show("Xóa suất chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadSuatChieu();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            DateTime ngayTim = dtp_NgayChieu.Value.Date;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string sql = @"
                    SELECT
                        SC.SC_Ma,
                        SC.P_Ma,
                        P.P_Ten,
                        SC.PC_Ma,
                        PC.PC_Ten,
                        SC.SC_NgayChieu,
                        SC.SC_GioBatDau,
                        SC.SC_GioKetThuc,
                        SC.SC_GiaVe
                    FROM SuatChieu SC
                    INNER JOIN Phim P ON SC.P_Ma = P.P_Ma
                    INNER JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
                    WHERE SC.SC_NgayChieu = @NgayChieu
                    ORDER BY SC.SC_GioBatDau";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngayTim;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_SuatChieu.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy suất chiếu nào trong ngày này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cbo_Phim.SelectedIndex = -1;
            cbo_PhongChieu.SelectedIndex = -1;
            dtp_NgayChieu.Value = DateTime.Now;
            dtp_GioBD.Value = DateTime.Now;
            txt_GioKT.Clear();

            LoadSuatChieu();
        }
    }
}