using System.Windows.Forms;

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
            QLPhim frm = new QLPhim();
            frm.ShowDialog();
        }

        private void btn_SuatChieu_Click(object sender, EventArgs e)
        {
            FrmSuatChieu frm = new FrmSuatChieu();
            frm.ShowDialog();
        }

        private void btn_DatVe_Click(object sender, EventArgs e)
        {
            FrmDatVe frm = new FrmDatVe();
            frm.ShowDialog();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            FrmHoaDon frm = new FrmHoaDon();
            frm.ShowDialog();
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            QLBaoCao frm = new QLBaoCao();
            frm.ShowDialog();
        }

        private void Baocaodoanhthu_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.ShowDialog();
        }
    }
}
