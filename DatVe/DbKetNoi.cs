using Microsoft.Data.SqlClient;
namespace DatVe
{
    public class DbKetNoi
    {
        private static string chuoiKetNoi =
            @"Data Source=localhost\SQLEXPRESS;
              Initial Catalog=DatVe;
              Integrated Security=True;
              TrustServerCertificate=True";

        public static SqlConnection MoKetNoi()
        {
            SqlConnection conn = new SqlConnection(chuoiKetNoi);
            conn.Open();
            return conn;
        }
    }
}