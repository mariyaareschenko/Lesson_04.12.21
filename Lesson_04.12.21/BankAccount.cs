using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Lesson_04._12._21
{
    public enum AccountType { Actual, Savings};
    sealed public class BankAccount : IDisposable
    {
        private long number;
        private decimal balance;
        private AccountType accountType;
        private static long uniq_num;
        private Queue transaction_queue = new Queue();
        bool disposed = false;
        internal BankAccount()
        {
            number = UniqNumber();
            accountType = Type();
            balance = 1000;
        }
        internal BankAccount(AccountType accountType)
        {
            number = UniqNumber();
            this.accountType = accountType;
            balance = 1000;
        }
        internal BankAccount(decimal balance)
        {
            number = UniqNumber();
            accountType = Type();
            this.balance = balance;
        }
        internal BankAccount(AccountType accountType, decimal balance)
        {
            number = UniqNumber();
            this.accountType = accountType;
            this.balance = balance;
        }
        public long UniqNumber()
        {
            return uniq_num++;
        }
        public AccountType Type()
        {
            return accountType;
        }
        public decimal Balance()
        {
            return balance;
        }
        public static bool operator == (BankAccount account1, BankAccount account2)
        {
            if ((account1.number == account2.number) && (account1.accountType == account2.accountType) && (account1.balance == account2.balance))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (BankAccount account1, BankAccount account2)
        {
            return !(account1 == account2);
        }
        public override bool Equals(object account1)
        {
            return this == (BankAccount)account1;
        }
        public override string ToString()
        {
            string res_account = $"Номер: {this.number} Тип: ";
            res_account += (this.accountType == AccountType.Actual) ? "Actual" : "Savings";
            res_account += $" Баланс: {this.balance}";
            return res_account;
        }
        public override int GetHashCode()
        {
            return (int)this.number;
        }
        public decimal PutMoney(decimal summa)
        {
            balance += summa;
            BankTransaction account_tran = new BankTransaction(summa);
            transaction_queue.Enqueue(account_tran);
            return balance;
        }
        public bool WithdrawMoney(decimal summa)
        {
            bool examination = (balance >= summa);
            if (examination)
            {
                balance -= summa;
                BankTransaction account_tran = new BankTransaction(-summa);
                transaction_queue.Enqueue(account_tran);
            }
            return examination;
        }
        public Queue Transaction()
        {
            return transaction_queue;
        }
        public void Dispose()
        {
            if (!disposed)
            {
                StreamWriter file_info = File.AppendText("Transactions.txt");
                file_info.WriteLine($"Account number:{number}");
                file_info.WriteLine($"Account balance:{balance}");
                file_info.WriteLine($"Account type: {accountType}");
                file_info.WriteLine("Transaction:");
                foreach (BankTransaction tran in transaction_queue)
                {
                    file_info.WriteLine($"Date/Time: {tran.When()}. Summa: {tran.Summa()}");
                }
                file_info.Close();
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }
        ~BankAccount()
        {
            Dispose();
        }
        public void PrintValues()
        {
            Console.WriteLine($"Account number: {number}");
            Console.WriteLine($"Account balance: {balance}");
            Console.WriteLine($"Account type: {accountType}");
        }
    }
}
