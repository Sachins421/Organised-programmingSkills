using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;

namespace BankingApp
{
    class ConnectionHelper
    {
        public static SqlConnection GetConnection()
        {
       
            String StrConn = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(StrConn);
            return conn;
        }
    }
}
