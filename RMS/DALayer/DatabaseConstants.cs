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
                
                    sqlConnection = new SqlConnection(connectionString);
                return sqlConnection;
            }
        }

        [ThreadStatic]
        private static SqlConnection sqlConnection = null;

        private static readonly string connectionString = "Initial Catalog=pc; Data Source=ANDREI-PC\\ANDREISQL;;Integrated Security= true";

        //private static readonly string connectionString = "Server= ELIZAC; Database=Local; Trusted_Connection= True;";

        //private static readonly string connectionString = "Initial Catalog=pc; Data Source=ANDREI-PC\\ANDREISQL;;Integrated Security= true";

        //private static readonly string connectionString = "Server= ANDREI-DESKTOP; Database=AndreiLocal; Trusted_Connection= True;";

        //private static readonly string connectionString = "Server= ANDREI-NETBOOK; Database=AndreiLocal; Trusted_Connection= True;";

        //private static readonly string connectionString = "Server= USER-PC\\SQLEXPRESS; Database= local; Trusted_Connection= true;";

        //private static readonly string connectionString = "SERVER= IoanasiPui\\SQLEXPRESS; Database= local; Trusted_Connection= True;";

        //private static readonly string connectionString = "Server= USER-PC\\SQLEXPRESS; Database= local; Trusted_Connection= true;";

        //private static readonly string connectionString = "SERVER= IoanasiPui\\SQLEXPRESS; Database= local; Trusted_Connection= True;";

        //private static readonly string connectionString = "Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123";

        private static readonly string connectionString = "Initial Catalog=PC; Data Source=ALEXANDRUIO-LAP;;Integrated Security= true";
    }
}
