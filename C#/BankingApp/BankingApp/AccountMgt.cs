using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace BankingApp
{
    internal class AccountMgt
    {
        SqlConnection conn;
        SqlCommand comm;

        public int GenerateAccount()
        {
            conn = ConnectionHelper.GetConnection();
            conn.Open();
            comm = new SqlCommand("GenerateAccoutNo",conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = comm.ExecuteReader();    
            reader.Read();
            int accno = Convert.ToInt32(reader["accno"]);
            return accno;
        }

        public string CreateAccount(Account account)
        {
            conn = ConnectionHelper.GetConnection();
            conn.Open();
            comm = new SqlCommand("CreateAccount",conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@AccountNo",account.AccountNo);
            comm.Parameters.AddWithValue("@FirstName",account.FirstName);
            comm.Parameters.AddWithValue("@LastName",account.LastName);
            comm.Parameters.AddWithValue("@City",account.City);
            comm.Parameters.AddWithValue("@State",account.state);
            comm.Parameters.AddWithValue("@DateofOpening",Convert.ToDateTime(account.OpeningDate));
            comm.Parameters.AddWithValue("@Amount",account.Amount);
            comm.Parameters.AddWithValue("@chequeFacil",account.Checque);
            comm.Parameters.AddWithValue("@AccountType",account.accunttype);
            comm.Parameters.AddWithValue("@Status",account.status);
            comm.ExecuteNonQuery();

            return "Account Created Successfully!......";
        }

        public string WithdrawAmount(int accountno, decimal amount)
        {
            conn = ConnectionHelper.GetConnection();
            conn.Open();
            comm = new SqlCommand("WithdrawAmount", conn);

            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@WithdrawAmount",accountno);
            comm.Parameters.AddWithValue("@AccountNo",amount);
            comm.Parameters.Add(new SqlParameter("@result",SqlDbType.VarChar,30));
            comm.Parameters["@result"].Direction = ParameterDirection.Output;
            comm.ExecuteNonQuery();

            String result = comm.Parameters["@result"].Value.ToString();
            return result;
        }
    }
}
