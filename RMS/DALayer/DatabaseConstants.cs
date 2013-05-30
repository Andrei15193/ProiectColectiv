using System.Data.SqlClient;

namespace ResourceManagementSystem.DataAccess
{
    static class DatabaseConstants
    {
        public static SqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        private static readonly SqlConnection connection = new SqlConnection("Server=ANDREI-NETBOOK; Database=AndreiLocal; Trusted_Connection=True;");
        //private static readonly SqlConnection connection = new SqlConnection("Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123");
    }
}
