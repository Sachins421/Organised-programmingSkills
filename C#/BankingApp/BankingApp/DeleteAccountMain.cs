using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class DeleteAccountMain
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            AccountMgt accountMgt = new AccountMgt();

            Console.WriteLine("Enter Account No.");
            account.AccountNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(accountMgt.DeleteAccount(account.AccountNo));
        }
    }
}
