using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DatVe
{
    public partial class QLBaoCao : Form
    {
        public QLBaoCao()
        {
            InitializeComponent();
        }
        private void QLBaoCao_Load(object sender, EventArgs e)
        {
            dtpThang.Value = DateTime.Now;
            dtpThangSC.Value = DateTime.Now;
            LoadDanhSachVeDaBan();
            LoadThongKeSuatChieu();
        }
        private void LoadDanhSachVeDaBan()
        {
            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string sql = @"SELECT V.Ve_Ma AS [Mã vé], 
                         P.P_Ten AS [Tên phim], 
                         SC.SC_NgayChieu AS [Ngày chiếu], 
                         SC.SC_GioBatDau AS [Giờ chiếu], 
                         PC.PC_Ten AS [Phòng], 
                         V.G_Ma AS [Ghế], 
                         V.Ve_Gia AS [Giá vé], 
                         ISNULL(KH.KH_Ten, N'Khách vãng lai') AS [Khách hàng], 
                         HD.HD_NgayLap AS [Ngày đặt]
                         FROM Ve V
                         INNER JOIN SuatChieu SC ON V.SC_Ma = SC.SC_Ma
                         INNER JOIN Phim P ON SC.P_Ma = P.P_Ma
                         INNER JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
                         LEFT JOIN ChiTietHoaDon CTHD ON V.Ve_Ma = CTHD.Ve_Ma
                         LEFT JOIN HoaDon HD ON CTHD.HD_Ma = HD.HD_Ma
                         LEFT JOIN KhachHang KH ON HD.KH_Ma = KH.KH_Ma";

                    // Nếu KHÔNG tích chọn "Tất cả" thì lọc theo tháng/năm đang chọn
                    // Lưu ý: Đang lọc theo Ngày chiếu (SC.SC_NgayChieu). 
                    // Nếu muốn tính doanh thu theo Ngày đặt vé thì đổi SC.SC_NgayChieu thành HD.HD_NgayLap
                    if (!chckTatCa.Checked)
                    {
                        sql += " WHERE MONTH(SC.SC_NgayChieu) = @Thang AND YEAR(SC.SC_NgayChieu) = @Nam";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (!chckTatCa.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Thang", dtpThang.Value.Month);
                        cmd.Parameters.AddWithValue("@Nam", dtpThang.Value.Year);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvVeDaBan.DataSource = dt;

                    // Tính tổng số vé và tổng doanh thu theo dữ liệu đã lọc
                    int tongVe = dt.Rows.Count;
                    decimal tongDoanhThu = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Giá vé"] != DBNull.Value)
                            tongDoanhThu += Convert.ToDecimal(row["Giá vé"]);
                    }

                    if (chckTatCa.Checked)
                    {
                        lblTongVe.Text = $"Tổng số vé (Tất cả): {tongVe:N0}";
                        lblTongDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VNĐ";
                    }
                    else
                    {
                        lblTongVe.Text = $"Tổng vé tháng {dtpThang.Value:MM/yyyy}: {tongVe:N0}";
                        lblTongDoanhThu.Text = $"Doanh thu tháng {dtpThang.Value:MM/yyyy}: {tongDoanhThu:N0} VNĐ";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vé đã bán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtpThangVe_ValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachVeDaBan();
        }
        private void chkTatCa_CheckedChanged(object sender, EventArgs e)
        {
            dtpThang.Enabled = !chckTatCa.Checked;
            LoadDanhSachVeDaBan();
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng cần tra cứu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string sqlKH = "SELECT KH_Ten, KH_LoaiKhach FROM KhachHang WHERE KH_SDT = @SDT";
                    SqlCommand cmdKH = new SqlCommand(sqlKH, conn);
                    cmdKH.Parameters.AddWithValue("@SDT", sdt);
                    SqlDataReader reader = cmdKH.ExecuteReader();

                    if (reader.Read())
                    {
                        string tenKH = reader["KH_Ten"].ToString();
                        string loaiKH = reader["KH_LoaiKhach"] != DBNull.Value ? reader["KH_LoaiKhach"].ToString() : "Thường";
                        lblTTKH.Text = $"Khách hàng: {tenKH} ({loaiKH})";
                    }
                    else
                    {
                        lblTTKH.Text = "Khách hàng: Không tìm thấy";
                        dgvLSKH.DataSource = null;
                        reader.Close();
                        MessageBox.Show("Không tìm thấy thông tin khách hàng với số điện thoại này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    reader.Close();
                    string sqlLichSu = @"SELECT hd.HD_Ma AS [Mã Hóa Đơn],
                                                hd.HD_NgayLap AS [Ngày Đặt],
                                                p.P_Ten AS [Tên Phim],
                                                pc.PC_Ten AS [Phòng Chiếu],
                                                sc.SC_NgayChieu AS [Ngày Chiếu],
                                                sc.SC_GioBatDau AS [Giờ Bắt Đầu],
                                                (g.G_Hang + CAST(g.G_So AS VARCHAR(10))) AS [Ghế],
                                                v.Ve_Gia AS [Giá Vé],
                                                v.Ve_TrangThai AS [Trạng Thái]
                                            FROM HoaDon hd
                                            JOIN KhachHang kh ON hd.KH_Ma = kh.KH_Ma
                                            JOIN ChiTietHoaDon ct ON hd.HD_Ma = ct.HD_Ma
                                            JOIN Ve v ON ct.Ve_Ma = v.Ve_Ma
                                            JOIN SuatChieu sc ON v.SC_Ma = sc.SC_Ma
                                            JOIN Phim p ON sc.P_Ma = p.P_Ma
                                            JOIN PhongChieu pc ON sc.PC_Ma = pc.PC_Ma
                                            JOIN Ghe g ON v.G_Ma = g.G_Ma
                                            WHERE kh.KH_SDT = @SDT
                                            ORDER BY hd.HD_NgayLap DESC";

                    SqlCommand cmdLS = new SqlCommand(sqlLichSu, conn);
                    cmdLS.Parameters.AddWithValue("@SDT", sdt);
                    SqlDataAdapter da = new SqlDataAdapter(cmdLS);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLSKH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu lịch sử khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadThongKeSuatChieu()
        {
            try
            {
                using (SqlConnection conn = DbKetNoi.MoKetNoi())
                {
                    string sql = @"SELECT SC.SC_Ma AS [Mã suất], 
                                 P.P_Ten AS [Tên phim], 
                                 PC.PC_Ten AS [Phòng chiếu], 
                                 SC.SC_NgayChieu AS [Ngày chiếu], 
                                 SC.SC_GioBatDau AS [Giờ chiếu], 
                                 COUNT(V.Ve_Ma) AS [Số vé đã bán], 
                                 ISNULL(SUM(V.Ve_Gia), 0) AS [Doanh thu]
                          FROM SuatChieu SC
                          INNER JOIN Phim P ON SC.P_Ma = P.P_Ma
                          INNER JOIN PhongChieu PC ON SC.PC_Ma = PC.PC_Ma
                          LEFT JOIN Ve V ON SC.SC_Ma = V.SC_Ma";

                    // Nếu không tích "Tất cả" thì lọc theo Tháng và Năm đang chọn
                    if (!TatCaSC.Checked)
                    {
                        sql += " WHERE MONTH(SC.SC_NgayChieu) = @Thang AND YEAR(SC.SC_NgayChieu) = @Nam";
                    }

                    sql += @" GROUP BY SC.SC_Ma, P.P_Ten, PC.PC_Ten, SC.SC_NgayChieu, SC.SC_GioBatDau
                      ORDER BY COUNT(V.Ve_Ma) DESC, SUM(V.Ve_Gia) DESC";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (!TatCaSC.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Thang", dtpThangSC.Value.Month);
                        cmd.Parameters.AddWithValue("@Nam", dtpThangSC.Value.Year);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSC.DataSource = dt;

                    if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0]["Số vé đã bán"]) > 0)
                    {
                        DataRow topRow = dt.Rows[0];
                        string tenPhim = topRow["Tên phim"].ToString();
                        string phong = topRow["Phòng chiếu"].ToString();
                        string ngayChieu = Convert.ToDateTime(topRow["Ngày chiếu"]).ToString("dd/MM/yyyy");
                        string gioChieu = topRow["Giờ chiếu"].ToString();
                        int soVe = Convert.ToInt32(topRow["Số vé đã bán"]);
                        decimal doanhThu = Convert.ToDecimal(topRow["Doanh thu"]);

                        lblSCHot.Text = $"Suất đông nhất: {tenPhim} ({phong} - {ngayChieu} {gioChieu}) | {soVe} vé - {doanhThu:N0} VNĐ";
                    }
                    else
                    {
                        lblSCHot.Text = "Suất chiếu đông khách nhất: Chưa có dữ liệu vé bán";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê suất chiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tự động cập nhật khi đổi tháng/năm
        private void dtpThangSC_ValueChanged(object sender, EventArgs e)
        {
            LoadThongKeSuatChieu();
        }

        // Tự động cập nhật khi tick/bỏ tick "Tất cả"
        private void chkTatCaSC_CheckedChanged(object sender, EventArgs e)
        {
            dtpThangSC.Enabled = TatCaSC.Checked;
            LoadThongKeSuatChieu();
        }

        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {
            LoadDanhSachVeDaBan();
        }
    }
}
