using System;
using System.Data.SqlClient;

namespace ResourceManagementSystem.DataAccess
{
    static class DatabaseConstants
    {
        public static SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }
        }

        [ThreadStatic]
        private static readonly SqlConnection sqlConnection = new SqlConnection("SERVER= IoanasiPui\\SQLEXPRESS; Database= local; Trusted_COnnection= True;");
        //private static readonly SqlConnection connection = new SqlConnection("Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123");
    }
}
