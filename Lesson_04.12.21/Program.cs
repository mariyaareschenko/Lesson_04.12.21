using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_04._12._21
{
    class Program
    {
        delegate List<Book> Sort();
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 12.1");
            long account_num1 = Bank.CreatAccount(AccountType.Actual, 100);
            long account_num2 = Bank.CreatAccount(AccountType.Actual, 100);
            BankAccount account1 = Bank.GetBankAccount(account_num1);
            BankAccount account2 = Bank.GetBankAccount(account_num2);
            BankAccount account3 = Bank.GetBankAccount(account_num1);
            if (account1 == account2)
            {
                Console.WriteLine("Аккаунты одинаковые");
            }
            else
            {
                Console.WriteLine("Аккаунты разные");
            }
            if (!account1.Equals(account3))
            {
                Console.WriteLine("Эти аккаунты разные");
            }
            else
            {
                Console.WriteLine("Эти аккаунты совпадают");
            }
            Console.WriteLine($"Аккаунт #1 - {account1}\nАккаунт #2 - {account2}\nАккаунт #3 - {account3}");

            Console.WriteLine("Упражнение 12.2");
            RationalNumbers num1 = new RationalNumbers(5, 7);
            RationalNumbers num2 = new RationalNumbers(5, 14);
            if (num1 == num2)
            {
                Console.WriteLine("Дроби равны");
            }
            else
            {
                Console.WriteLine("Дроби не равны");
            }
            RationalNumbers sum_num = num1 + num2;
            Console.WriteLine(sum_num.ToString());
            if (num1 > num2)
            {
                Console.WriteLine($"{num1.ToString()} > {num2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{num1.ToString()} < {num2.ToString()}");
            }

            Console.WriteLine("Домашнее задание 12.1");
            ComplexNumbers complex1 = new ComplexNumbers(5, -5);
            ComplexNumbers complex2 = new ComplexNumbers(7, 4);
            if (complex1 == complex2)
            {
                Console.WriteLine($"{complex1.ToString()} == {complex2.ToString()}");
            }
            else
            {
                Console.WriteLine($"{complex1.ToString()} != {complex2.ToString()}");
            }
            ComplexNumbers result = complex1 * complex2;
            Console.WriteLine(result.ToString());

            Console.WriteLine("Домашнее задание 12.2");
            List<Book> books = new List<Book>();
            Book book1 = new Book { Name = "Идиот", Author = "Ф.М.Достоеквский", Publisher = "Росмен" };
            Book book2 = new Book { Name = "Ася", Author = "И.С.Тургенев", Publisher = "Эксмо" };
            Book book3 = new Book { Name = "Вишневый сад", Author = "А.П.Чехов", Publisher = "АСТ" };
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            Container container = new Container(books);
            Console.WriteLine("Сортиовка по названию");
            Sort sort = container.SortName;
            books = sort();
            Print(books);
            Console.WriteLine("Сортиовка по автору");
            sort = container.SortAuthor;
            books = sort();
            Print(books);
            Console.WriteLine("Сортиовка по изаднию");
            sort = container.SortPublisher;
            books = sort();
            Print(books);
            Console.ReadKey();
        }
        static void Print(List<Book> books)
        {
            foreach(var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
