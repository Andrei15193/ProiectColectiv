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
        public DBConnection()
        {
            //this.Connection = new SqlConnection("Initial Catalog=Andrei15193_sqldb; Data Source=andrei15193.tk,779; User=Andrei15193_RMSuser; Password=d3m3nt14l123");
            this.Connection = new SqlConnection("Initial Catalog=tpcc; Data Source=ANDREI-PC\\ANDREISQL;;Integrated Security= true");
        }

        public SqlConnection Connection
        {
            get;
            protected set;
        }
    }
}
