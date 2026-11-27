namespace DatVe
{
    public class GheThuong : Ghe
    {
        public GheThuong(string maGhe) : base(maGhe, "Thường") { }

        public override decimal TinhGia(decimal giaCoBan)
        {
            return giaCoBan;
        }
    }
}