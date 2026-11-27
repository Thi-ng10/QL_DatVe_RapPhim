namespace DatVe
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Menu());
            Application.Run(new FrmSuatChieu());
            Application.Run(new frmBaoCao());

        }
    }
}