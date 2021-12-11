using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 13.1");
            long num_acc1 = Bank.CreatAccount();
            long num_acc2 = Bank.CreatAccount(5);
            BankAccount account1 = Bank.GetBankAccount(num_acc1);
            BankAccount account2 = Bank.GetBankAccount(num_acc2);
            account1.Holder = "Tom";
            account2.Holder = "Sid";
            TestPutMoney(account1);
            TestWithdrawMoney(account2);
            account1.PrintValues();
            account2.PrintValues();

            Console.WriteLine("Упражнение 13.2");
            for (int i = 0; i < 5; i++)
            {
                account1.PutMoney(100);
                account2.WithdrawMoney(50);
            }
            PrintTransaction(account1);

            Console.WriteLine("Домашнее задание 13.1");
            Building building = new Building { Number = 1, Height = 100, Count_floors = 10, Count_apartments = 15, Count_entrances = 15 };
            building.PrintValues();

            Console.WriteLine("Домашнее задание 13.2");
            ArrayBuliding arraybuliding = new ArrayBuliding();
            arraybuliding[0] = new Building { Number = 2, Height = 100, Count_floors = 5, Count_apartments = 12, Count_entrances = 10 };
            arraybuliding[1] = new Building { Number = 2, Height = 300, Count_floors = 6, Count_apartments = 13, Count_entrances = 11 };
            arraybuliding[2] = new Building { Number = 2, Height = 400, Count_floors = 7, Count_apartments = 14, Count_entrances = 12 };
            arraybuliding[3] = new Building { Number = 2, Height = 400, Count_floors = 7, Count_apartments = 14, Count_entrances = 12 };
            arraybuliding[4] = new Building { Number = 2, Height = 500, Count_floors = 8, Count_apartments = 15, Count_entrances = 13 };
            arraybuliding[5] = new Building { Number = 2, Height = 600, Count_floors = 9, Count_apartments = 16, Count_entrances = 14 };
            arraybuliding[6] = new Building { Number = 2, Height = 700, Count_floors = 10, Count_apartments = 17, Count_entrances = 15 };
            arraybuliding[7] = new Building { Number = 2, Height = 800, Count_floors = 11, Count_apartments = 18, Count_entrances = 16 };
            arraybuliding[8] = new Building { Number = 2, Height = 900, Count_floors = 12, Count_apartments = 19, Count_entrances = 17 };
            arraybuliding[9] = new Building { Number = 2, Height = 200, Count_floors = 13, Count_apartments = 20, Count_entrances = 18 };
            Building building1 = arraybuliding[0];
            Console.WriteLine(building1?.Height);
            Console.ReadKey();

        }
        public static void TestPutMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите положить на счёт");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            acc.PutMoney(sum);
        }
        public static void TestWithdrawMoney(BankAccount acc)
        {
            Console.WriteLine("Введите сумму, которую хотите снять со счёта");
            decimal sum;
            while (!decimal.TryParse(Console.ReadLine(), out sum))
            {
                Console.WriteLine("Неверный ввод, попробуйте еще раз");
            }
            if (!acc.WithdrawMoney(sum))
            {
                Console.WriteLine("Невозможно снять данную сумму денег");
            }
        }
        static void PrintTransaction(BankAccount bank_account)
        {
            Console.WriteLine($"Transaction:");
            for (int counter = 0; counter < bank_account.Transaction().Count; counter++)
            {
                BankTransaction tran = bank_account[counter];
                Console.WriteLine($"Date/Time: {tran.When}. Summa: {tran.Summa}");
            }
        }
    }
}
