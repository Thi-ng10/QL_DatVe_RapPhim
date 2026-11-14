namespace QLDatVe
{
    public class GheDoi : Ghe
    {
        public GheDoi(string maGhe) : base(maGhe, "Đôi") { }

        public override decimal TinhGia(decimal giaCoBan)
        {
            return giaCoBan + 20000m; // Phụ thu ghế đôi
        }
    }
}