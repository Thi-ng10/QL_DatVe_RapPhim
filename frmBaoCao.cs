using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DatVe
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
            this.Load += FrmBaoCao_Load;
            btn_ThongKe.Click += btn_ThongKe_Click;
            btn_LamMoi.Click += btn_LamMoi_Click;
        }
        private void FrmBaoCao_Load(object sender, EventArgs e)
        {
            cb_LoaiBaoCao.Items.Clear();
            cb_LoaiBaoCao.Items.Add("Doanh thu theo phim");
            cb_LoaiBaoCao.Items.Add("Doanh thu theo ngày");
            cb_LoaiBaoCao.Items.Add("Doanh thu theo tháng");
            cb_LoaiBaoCao.SelectedIndex = 0;
            dtp_TuNgay.Value = DateTime.Today.AddDays(-30);
            dtp_DenNgay.Value = DateTime.Today;
            LoadPhim();
        }
        private void LoadPhim()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
            SELECT P_Ma, P_Ten
            FROM Phim
            ORDER BY P_Ten";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow row = dt.NewRow();
                row["P_Ma"] = DBNull.Value;
                row["P_Ten"] = "Tất cả phim";
                dt.Rows.InsertAt(row, 0);
                cb_Phim.DataSource = dt;
                cb_Phim.DisplayMember = "P_Ten";
                cb_Phim.ValueMember = "P_Ma";
                cb_Phim.SelectedIndex = 0;
            }
        }
        private bool KiemTraNgay()
        {
            if (dtp_TuNgay.Value.Date > dtp_DenNgay.Value.Date)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!");

                return false;
            }
            return true;
        }
        private void BaoCaoTheoPhim()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
            SELECT
                P.P_Ma,
                P.P_Ten,
                COUNT(DISTINCT V.Ve_Ma) AS SoVeBan,
                SUM(CT.CTHD_DonGia) AS DoanhThu
            FROM Phim P
            INNER JOIN SuatChieu SC ON P.P_Ma = SC.P_Ma
            INNER JOIN Ve V ON SC.SC_Ma = V.SC_Ma
            INNER JOIN ChiTietHoaDon CT ON V.Ve_Ma = CT.Ve_Ma
            INNER JOIN HoaDon HD ON CT.HD_Ma = HD.HD_Ma
            WHERE HD.HD_TrangThai = N'Đã thanh toán'
              AND HD.HD_NgayLap >= @TuNgay
              AND HD.HD_NgayLap < DATEADD(DAY, 1, @DenNgay)";

                bool filterPhim = cb_Phim.SelectedValue != null && cb_Phim.SelectedValue != DBNull.Value;
                if (filterPhim)
                {
                    sql += " AND P.P_Ma = @P_Ma";
                }

                sql += @" GROUP BY P.P_Ma, P.P_Ten
                  ORDER BY DoanhThu DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = dtp_TuNgay.Value.Date;
                    cmd.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = dtp_DenNgay.Value.Date;

                    if (filterPhim)
                    {
                        cmd.Parameters.Add("@P_Ma", SqlDbType.Int).Value = Convert.ToInt32(cb_Phim.SelectedValue);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv_BaoCao.DataSource = dt;
                    dgv_BaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dgv_BaoCao.Columns["P_Ma"] != null) dgv_BaoCao.Columns["P_Ma"].Visible = false;
                    if (dgv_BaoCao.Columns["P_Ten"] != null) dgv_BaoCao.Columns["P_Ten"].HeaderText = "Tên phim";
                    if (dgv_BaoCao.Columns["SoVeBan"] != null) dgv_BaoCao.Columns["SoVeBan"].HeaderText = "Số vé bán";
                    if (dgv_BaoCao.Columns["DoanhThu"] != null) dgv_BaoCao.Columns["DoanhThu"].HeaderText = "Doanh thu";

                    if (dt.Rows.Count == 0)
                    {
                        lbl_TongDoanhThu.Text = "0 VNĐ";
                        MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!");
                        return;
                    }
                    TinhTongDoanhThu(dt);
                }
            }
        }
        private void BaoCaoTheoNgay()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
            SELECT
                CAST(HD.HD_NgayLap AS DATE) AS Ngay,
                COUNT(DISTINCT V.Ve_Ma) AS SoVeBan,
                SUM(CT.CTHD_DonGia) AS DoanhThu
            FROM HoaDon HD
            INNER JOIN ChiTietHoaDon CT ON HD.HD_Ma = CT.HD_Ma
            INNER JOIN Ve V ON CT.Ve_Ma = V.Ve_Ma
            INNER JOIN SuatChieu SC ON V.SC_Ma = SC.SC_Ma
            WHERE HD.HD_TrangThai = N'Đã thanh toán'
              AND HD.HD_NgayLap >= @TuNgay
              AND HD.HD_NgayLap < DATEADD(DAY, 1, @DenNgay)
            GROUP BY CAST(HD.HD_NgayLap AS DATE)
            ORDER BY Ngay";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@TuNgay",
                        SqlDbType.DateTime).Value = dtp_TuNgay.Value.Date;

                    cmd.Parameters.Add("@DenNgay",
                        SqlDbType.DateTime).Value = dtp_DenNgay.Value.Date;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_BaoCao.DataSource = dt;
                    TinhTongDoanhThu(dt);
                }
            }
        }
        private void BaoCaoTheoThang()
        {
            using (SqlConnection conn = DbKetNoi.MoKetNoi())
            {
                string sql = @"
            SELECT
                YEAR(HD.HD_NgayLap) AS Nam,
                MONTH(HD.HD_NgayLap) AS Thang,
                COUNT(DISTINCT V.Ve_Ma) AS SoVeBan,
                SUM(CT.CTHD_DonGia) AS DoanhThu
            FROM HoaDon HD
            INNER JOIN ChiTietHoaDon CT ON HD.HD_Ma = CT.HD_Ma
            INNER JOIN Ve V ON CT.Ve_Ma = V.Ve_Ma
            WHERE HD.HD_TrangThai = N'Đã thanh toán'
              AND HD.HD_NgayLap >= @TuNgay
              AND HD.HD_NgayLap < DATEADD(DAY, 1, @DenNgay)
            GROUP BY
                YEAR(HD.HD_NgayLap),
                MONTH(HD.HD_NgayLap)
            ORDER BY Nam, Thang";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@TuNgay",
                        SqlDbType.DateTime).Value = dtp_TuNgay.Value.Date;

                    cmd.Parameters.Add("@DenNgay",
                        SqlDbType.DateTime).Value = dtp_DenNgay.Value.Date;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_BaoCao.DataSource = dt;
                    TinhTongDoanhThu(dt);
                }
            }
        }
        private void TinhTongDoanhThu(DataTable dt)
        {
            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["DoanhThu"] != DBNull.Value)
                {
                    tong += Convert.ToDecimal(row["DoanhThu"]);
                }
            }
            lbl_TongDoanhThu.Text = tong.ToString("N0") + " VNĐ";
        }
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            if (!KiemTraNgay())
                return;

            if (cb_LoaiBaoCao.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!");
                return;
            }

            switch (cb_LoaiBaoCao.SelectedItem.ToString())
            {
                case "Doanh thu theo phim":
                    BaoCaoTheoPhim();
                    break;
                case "Doanh thu theo ngày":
                    BaoCaoTheoNgay();
                    break;
                case "Doanh thu theo tháng":
                    BaoCaoTheoThang();
                    break;
            }
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            cb_LoaiBaoCao.SelectedIndex = 0;
            cb_Phim.SelectedIndex = 0;
            dtp_TuNgay.Value = DateTime.Today.AddDays(-30);
            dtp_DenNgay.Value = DateTime.Today;
            dgv_BaoCao.DataSource = null;
            lbl_TongDoanhThu.Text = "0 VNĐ";
        }
    }
}
