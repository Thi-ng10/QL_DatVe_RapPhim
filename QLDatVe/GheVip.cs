namespace QLDatVe
{
    public class GheVip : Ghe
    {
        public GheVip(string maGhe) : base(maGhe, "VIP") { }

        public override decimal TinhGia(decimal giaCoBan)
        {
            return giaCoBan + 10000m; // Phụ thu VIP
        }
    }
}