﻿using System;


namespace BankingApp
{
    class WithDrawMain
    {
       static void Main(string[] args)
        {
            Account account = new Account();
            AccountMgt accountMgt = new AccountMgt();

            Console.WriteLine("Enter Account No.");
            account.AccountNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount to Withdraw");
            account.Amount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine(accountMgt.WithdrawAmount(account.AccountNo, account.Amount));
        }
    }
}
