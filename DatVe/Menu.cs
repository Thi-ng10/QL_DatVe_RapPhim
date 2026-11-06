namespace DatVe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_Phong_Click(object sender, EventArgs e)
        {
            QLPhongChieu frm = new QLPhongChieu();
            frm.ShowDialog();
        }

        private void btn_Ghe_Click(object sender, EventArgs e)
        {
            QLGhe frm = new QLGhe();
            frm.ShowDialog();
        }

        private void btn_Phim_Click(object sender, EventArgs e)
        {
            // Mo Form quan ly phim
        }

        private void btn_SuatChieu_Click(object sender, EventArgs e)
        {
            // Mo Form quan ly suat chieu
        }

        private void btn_DatVe_Click(object sender, EventArgs e)
        {
            // Mo Form dat ve
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            // Mo Form hoa don
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            // Mo Form bao cao
        }

    }
}
