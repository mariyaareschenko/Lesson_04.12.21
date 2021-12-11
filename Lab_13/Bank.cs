using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab_13
{
    class Bank
    {
        private static Hashtable accounts = new Hashtable();
        public static long CreatAccount()
        {
            BankAccount bankAccount = new BankAccount();
            long number = bankAccount.Number;
            accounts[number] = bankAccount;
            return number;
        }
        public static long CreatAccount(AccountType accountType, decimal balance)
        {
            BankAccount bankAccount = new BankAccount(AccountType.Actual, 1500); ;
            long number = bankAccount.Number;
            accounts[number] = bankAccount;
            return number;
        }
        public static long CreatAccount(AccountType accountType)
        {
            BankAccount bankAccount = new BankAccount(AccountType.Savings); ;
            long number = bankAccount.Number;
            accounts[number] = bankAccount;
            return number;
        }
        public static long CreatAccount(decimal balance)
        {
            BankAccount bankAccount = new BankAccount(2000); ;
            long number = bankAccount.Number;
            accounts[number] = bankAccount;
            return number;
        }
        public static bool CloseAccount(long number)
        {
            BankAccount closing = (BankAccount)accounts[number];
            if (closing != null)
            {
                accounts.Remove(number);
                closing.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static BankAccount GetBankAccount(long number)
        {
            return (BankAccount)accounts[number];
        }
    }
}
