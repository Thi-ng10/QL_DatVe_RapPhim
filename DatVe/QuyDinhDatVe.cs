using Microsoft.Data.SqlClient;

namespace DatVe
{
    /// <summary>
    /// Các quy định dùng chung cho form Đặt vé và Hóa đơn.
    /// </summary>
    public static class QuyDinhDatVe
    {
        // Thời gian giữ ghế tạm thời (phút)
        public const int SoPhutGiu = 5;

        // Phần trăm giảm giá theo loại khách.
        // TODO: xác nhận lại mức giảm với nhóm (đây là mức giả định).
        // Tên loại khách phải trùng với ràng buộc CK_KhachHang_LoaiKhach trong CSDL.
        public static readonly Dictionary<string, int> GiamGia = new()
        {
            ["Thường"] = 0,
            ["Học sinh - Sinh viên"] = 20,
            ["Trẻ em"] = 30,
            ["Người cao tuổi"] = 30,
            ["Người có công với cách mạng"] = 50,
            ["Người khuyết tật"] = 50
        };

        // Phương thức thanh toán (cột HD_PhuongThucThanhToan không có CHECK nên có thể đổi tùy nhóm)
        public static readonly string[] PhuongThuc = { "Tiền mặt", "Chuyển khoản", "Thẻ" };

        public static int GiamTheoLoai(string loaiKhach)
        {
            return GiamGia.TryGetValue(loaiKhach, out int phanTram) ? phanTram : 0;
        }

        // Giá sau giảm, làm tròn giống công thức trong câu lệnh SQL ở bước thanh toán
        public static int TinhGia(int giaGoc, string loaiKhach)
        {
            decimal gia = giaGoc * (100 - GiamTheoLoai(loaiKhach)) / 100m;
            return (int)Math.Round(gia, 0, MidpointRounding.AwayFromZero);
        }

        // Lỗi vi phạm chỉ mục/khóa duy nhất (trùng ghế trong cùng suất chiếu)
        public static bool LaLoiTrungKhoa(SqlException ex)
        {
            return ex.Number == 2601 || ex.Number == 2627;
        }
    }
}