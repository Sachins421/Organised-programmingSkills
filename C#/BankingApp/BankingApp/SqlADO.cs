using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BankingApp
{
     class SqlADO
    {
        public static SqlConnection GetConnection()
        {
            String Strconn = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(Strconn);
            return conn;
        }
    }
}
