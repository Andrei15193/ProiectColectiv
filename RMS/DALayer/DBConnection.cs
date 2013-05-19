using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    class DBConnection
    {
        private static SqlConnection sqlconnection = null;

        public static SqlConnection GetConnection()
        {
            if (sqlconnection == null)
            {
                //sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
                sqlconnection = new SqlConnection("Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123");
            }
            return sqlconnection;
        }

    }
}
