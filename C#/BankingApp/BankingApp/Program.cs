using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountMgt accountMgt = new AccountMgt();

            Account account = new Account();
            account.AccountNo = accountMgt.GenerateAccount();

            Console.WriteLine("Enter First Name");
            account.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            account.LastName = Console.ReadLine();
            Console.WriteLine("Enter City");
            account.City = Console.ReadLine();
            Console.WriteLine("Enter State");
            account.state = Console.ReadLine();
            Console.WriteLine("Enter Amount");
            account.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter Cheque Faciltiy");
            account.Checque = Console.ReadLine();
            Console.WriteLine("Enter Opening Date");
            account.OpeningDate = Console.ReadLine();
            Console.WriteLine("Enter Account type");
            account.accunttype = Console.ReadLine();
            Console.WriteLine("Enter status");
            account.status = Console.ReadLine();



            Console.WriteLine(accountMgt.CreateAccount(account));


        }
    }
}
