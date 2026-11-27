using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatVe
{
    public partial class FrmSuatChieu : Form
    {
        private bool isLoaded = false;

        public FrmSuatChieu()
        {
            InitializeComponent();
            this.Load += FrmSuatChieu_Load;
            btn_Them.Click += btn_Them_Click;
            btn_Sua.Click += btn_Sua_Click;
            btn_Xoa.Click += btn_Xoa_Click;
            btn_TimKiem.Click += btn_TimKiem_Click;
            btn_LamMoi.Click += btn_LamMoi_Click;
            cb_Phim.SelectedIndexChanged += cb_Phim_SelectedIndexChanged;
            dtp_GioBD.ValueChanged += dtp_GioBD_ValueChanged;
            dgv_SuatChieu.CellClick += dgv_SuatChieu_CellClick;
        }
        private void FrmSuatChieu_Load(object sender, EventArgs e)
        {
            isLoaded = false; 
            dtp_GioBD.Format = DateTimePickerFormat.Custom;
            dtp_GioBD.CustomFormat = "HH:mm";
            dtp_GioBD.ShowUpDown = true;
            txt_GioKT.ReadOnly = true;
            LoadPhim();
            LoadPhong();
            LoadSuatChieu();
            isLoaded = true; 
        }
        private void LoadPhim()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
                    SELECT P_Ma, P_Ten, P_ThoiLuong
                    FROM Phim
                    ORDER BY P_Ten";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cb_Phim.DataSource = dt;
                cb_Phim.DisplayMember = "P_Ten";
                cb_Phim.ValueMember = "P_Ma";
                cb_Phim.SelectedIndex = -1;
            }
        }
        private void LoadPhong()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
                    SELECT PC_Ma, PC_Ten
                    FROM PhongChieu
                    ORDER BY PC_Ma";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cb_PhongChieu.DataSource = dt;
                cb_PhongChieu.DisplayMember = "PC_Ten";
                cb_PhongChieu.ValueMember = "PC_Ma";
                cb_PhongChieu.SelectedIndex = -1;
            }
        }
        private void LoadSuatChieu()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
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
            LEFT JOIN Phim P ON SC.P_Ma = P.P_Ma
            LEFT JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
            ORDER BY SC.SC_Ma ASC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgv_SuatChieu.DataSource = null;
                dgv_SuatChieu.Columns.Clear();

                dgv_SuatChieu.AutoGenerateColumns = true;
                dgv_SuatChieu.DataSource = dt;

                dgv_SuatChieu.ReadOnly = true;
                dgv_SuatChieu.AllowUserToAddRows = false;
                dgv_SuatChieu.AllowUserToDeleteRows = false;
                dgv_SuatChieu.MultiSelect = false;
                dgv_SuatChieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv_SuatChieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv_SuatChieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv_SuatChieu.RowTemplate.Height = 25;

                if (dgv_SuatChieu.Columns.Contains("SC_Ma")) dgv_SuatChieu.Columns["SC_Ma"].HeaderText = "Mã suất";
                if (dgv_SuatChieu.Columns.Contains("P_Ma")) dgv_SuatChieu.Columns["P_Ma"].HeaderText = "Mã phim";
                if (dgv_SuatChieu.Columns.Contains("P_Ten")) dgv_SuatChieu.Columns["P_Ten"].HeaderText = "Tên phim";
                if (dgv_SuatChieu.Columns.Contains("PC_Ma")) dgv_SuatChieu.Columns["PC_Ma"].HeaderText = "Mã phòng";
                if (dgv_SuatChieu.Columns.Contains("PC_Ten")) dgv_SuatChieu.Columns["PC_Ten"].HeaderText = "Phòng chiếu";
                if (dgv_SuatChieu.Columns.Contains("SC_NgayChieu")) dgv_SuatChieu.Columns["SC_NgayChieu"].HeaderText = "Ngày chiếu";
                if (dgv_SuatChieu.Columns.Contains("SC_GioBatDau")) dgv_SuatChieu.Columns["SC_GioBatDau"].HeaderText = "Giờ BĐ";
                if (dgv_SuatChieu.Columns.Contains("SC_GioKetThuc")) dgv_SuatChieu.Columns["SC_GioKetThuc"].HeaderText = "Giờ KT";
                if (dgv_SuatChieu.Columns.Contains("SC_GiaVe")) dgv_SuatChieu.Columns["SC_GiaVe"].HeaderText = "Giá vé";
            }
        }
        private void cb_Phim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            TinhGioKetThuc();
        }
        private void dtp_GioBD_ValueChanged(object sender, EventArgs e)
        {
            if (!isLoaded) return;
            TinhGioKetThuc();
        }
        private void TinhGioKetThuc()
        {
            if (cb_Phim.SelectedIndex < 0 || cb_Phim.SelectedItem == null)
                return;
            DataRowView row = cb_Phim.SelectedItem as DataRowView;
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
                return soLuong > 0;
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

                if (row.Cells["P_Ma"].Value != DBNull.Value && row.Cells["P_Ma"].Value != null)
                    cb_Phim.SelectedValue = row.Cells["P_Ma"].Value;

                if (row.Cells["PC_Ma"].Value != DBNull.Value && row.Cells["PC_Ma"].Value != null)
                    cb_PhongChieu.SelectedValue = row.Cells["PC_Ma"].Value;

                if (row.Cells["SC_NgayChieu"].Value != DBNull.Value && row.Cells["SC_NgayChieu"].Value != null)
                    dtp_NgayChieu.Value = Convert.ToDateTime(row.Cells["SC_NgayChieu"].Value);

                if (row.Cells["SC_GioBatDau"].Value != DBNull.Value && row.Cells["SC_GioBatDau"].Value != null)
                {
                    TimeSpan gioBD = (TimeSpan)row.Cells["SC_GioBatDau"].Value;
                    dtp_GioBD.Value = DateTime.Today.Add(gioBD);
                }
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (cb_Phim.SelectedIndex < 0 || cb_PhongChieu.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Phim và Phòng chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int maPhim = Convert.ToInt32(cb_Phim.SelectedValue);
            int maPhong = Convert.ToInt32(cb_PhongChieu.SelectedValue);
            DateTime ngayChieu = dtp_NgayChieu.Value.Date;
            TimeSpan gioBatDau = dtp_GioBD.Value.TimeOfDay;
            TimeSpan gioKetThuc;

            if (!TimeSpan.TryParse(txt_GioKT.Text, out gioKetThuc))
            {
                MessageBox.Show("Giờ kết thúc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int giaCoBan = 70000; 
            if (!string.IsNullOrEmpty(txt_GiaCoBan.Text))
            {
                if (!int.TryParse(txt_GiaCoBan.Text, out giaCoBan))
                {
                    MessageBox.Show("Giá cơ bản không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {

                if (KiemTraTrungLich(conn, null, maPhong, ngayChieu, gioBatDau, gioKetThuc))
                {
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
            int maPhim = Convert.ToInt32(cb_Phim.SelectedValue);
            int maPhong = Convert.ToInt32(cb_PhongChieu.SelectedValue);
            DateTime ngayChieu = dtp_NgayChieu.Value.Date;
            TimeSpan gioBatDau = dtp_GioBD.Value.TimeOfDay;
            TimeSpan gioKetThuc;

            if (!TimeSpan.TryParse(txt_GioKT.Text, out gioKetThuc))
            {
                MessageBox.Show("Giờ kết thúc không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
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
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
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
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
                    SELECT
                        SC.SC_Ma,
                        SC.P_Ma,
                        ISNULL(P.P_Ten, N'Chưa rõ phim') AS P_Ten,
                        SC.PC_Ma,
                        ISNULL(PC.PC_Ten, N'Chưa rõ phòng') AS PC_Ten,
                        SC.SC_NgayChieu,
                        SC.SC_GioBatDau,
                        SC.SC_GioKetThuc,
                        SC.SC_GiaVe
                    FROM SuatChieu SC
                    LEFT JOIN Phim P ON SC.P_Ma = P.P_Ma
                    LEFT JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
                    WHERE SC.SC_NgayChieu = @NgayChieu
                    ORDER BY SC.SC_GioBatDau";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@NgayChieu", SqlDbType.Date).Value = ngayTim;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_SuatChieu.DataSource = null;
                    dgv_SuatChieu.AutoGenerateColumns = true;
                    dgv_SuatChieu.DataSource = dt;
                    dgv_SuatChieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_SuatChieu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv_SuatChieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dgv_SuatChieu.ReadOnly = true;
                    dgv_SuatChieu.AllowUserToAddRows = false;
                    dgv_SuatChieu.AllowUserToDeleteRows = false;
                    dgv_SuatChieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv_SuatChieu.MultiSelect = false;
                    dgv_SuatChieu.ScrollBars = ScrollBars.Both;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy suất chiếu nào trong ngày này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            isLoaded = false;
            cb_Phim.SelectedIndex = -1;
            cb_PhongChieu.SelectedIndex = -1;
            dtp_NgayChieu.Value = DateTime.Now;
            dtp_GioBD.Value = DateTime.Now;
            txt_GioKT.Clear();
            isLoaded = true;
            LoadSuatChieu();
        }
    }
}