namespace QLDatVe
{
    public abstract class Ghe
    {
        public string MaGhe { get; set; }
        public string LoaiGhe { get; set; }

        public Ghe() { }

        public Ghe(string maGhe, string loaiGhe)
        {
            MaGhe = maGhe;
            LoaiGhe = loaiGhe;
        }

        public abstract decimal TinhGia(decimal giaCoBan);
    }
}