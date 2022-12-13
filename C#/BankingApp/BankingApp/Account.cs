using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Account
    {
        public int AccountNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City  { get; set; }
        public string state { get; set; }
        public string OpeningDate { get; set; } 
        public decimal Amount { get; set; } 
        public string Checque { get; set; }
        public string accunttype { get; set; }
        public string status { get; set; }


        public override string ToString()
        {
            return "Accout No." + AccountNo + "First Name " + FirstName + "Last Name " + LastName + "City  " + City + "State " + state + "OpeningDate" + OpeningDate
                + "Amount " + Amount + "cheque " + Checque + "Account Type " + accunttype + "Status " + status;

        }

    }
}