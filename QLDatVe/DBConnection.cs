using Microsoft.Data.SqlClient;

namespace DatVe
{
    public class DBConnection
    {
        private static string connectionString = @"Data Source=ADMIN;Initial Catalog=DatVe;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}