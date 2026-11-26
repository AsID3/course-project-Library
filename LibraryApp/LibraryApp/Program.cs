using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    internal class Program
    {
        static string[] titles = new string[100];
        static int[] years = new int[100];
        static int[] pages = new int[100];

        static int count = 0;

        static void Main(string[] args)
        {
            bool i = true;

            while (i)
            {
                Console.WriteLine("\n=== БИБЛИОТЕКА ===");
                Console.WriteLine("1. Просмотреть книги");
                Console.WriteLine("2. Добавить книгу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowBooks();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "0":
                        i = false;
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню!");
                        break;
                }
            }
        }

        static void ShowBooks()
        {
            if (count == 0)
            {
                Console.WriteLine("Библиотека пока пуста!");
                return;
            }

            Console.WriteLine("\n=== СПИСОК КНИГ ===");

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("{0,-5} {1,-22} {2,-10} {3,-10}",
                "№", "Название", "Год", "Страниц");
            Console.WriteLine("-----------------------------------------------");

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0,-5} {1,-22} {2,-10} {3,-10}",
                    i + 1, titles[i], years[i], pages[i]);
            }

            Console.WriteLine("-----------------------------------------------");
        }


        static void AddBook()
        {
            if (count >= titles.Length)
            {
                Console.WriteLine("Библиотека заполнена!");
                return;
            }

            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(title))
            {
                Console.Write("Название не может быть пустым. Повторите ввод: ");
                title = Console.ReadLine();
            }

            Console.Write("Введите год издания: ");
            int year;

            while (!int.TryParse(Console.ReadLine(), out year) || year <= 0 || year > DateTime.Now.Year)
            {
                Console.Write("Введите корректный год издания: ");
            }

            Console.Write("Введите количество страниц: ");
            int pageCount;

            while (!int.TryParse(Console.ReadLine(), out pageCount) || pageCount <= 0)
            {
                Console.Write("Введите корректное количество страниц: ");
            }

            titles[count] = title;
            years[count] = year;
            pages[count] = pageCount;

            count++;

            Console.WriteLine("Книга успешно добавлена!");
        }

    }
}
    