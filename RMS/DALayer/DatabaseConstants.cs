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
                if (sqlConnection == null)
                    sqlConnection = new SqlConnection("Server=ELIZAC; Database=Local; Trusted_Connection= True;");
                return sqlConnection;
            }
        }

        [ThreadStatic]
        private static SqlConnection sqlConnection;

        //private static readonly SqlConnection sqlConnection = new SqlConnection("SERVER= IoanasiPui\\SQLEXPRESS; Database= local; Trusted_Connection= True;");

        //private static readonly SqlConnection connection = new SqlConnection("Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123");
    }
}
