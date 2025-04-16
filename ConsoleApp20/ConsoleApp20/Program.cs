using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    internal class Program
    {
        static int[,] a;
        static void Task1()
        {
            Console.Write("\nВведите количество вещей: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите вместимость рюкзака: ");
            int w = int.Parse(Console.ReadLine());

            int[,] a = new int[n, 2];
            Console.WriteLine("\nВведите попарно стоимость и вес каждого предмета\n" +
                "(Сначала введите стоимость предмета, а затем через Enter его вес)");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Предмет " + (i + 1) + ":");
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            int[] bp = new int[w + 1];
            bp[0] = 0;

            for (int i = 1; i <= w; i++)
            {
                bp[i] = bp[i - 1];
                for (int j = 0; j < n; j++)
                {
                    if (a[j, 1] <= i)
                    {
                        bp[i] = Math.Max(bp[i], bp[i - a[j, 1]] + a[j, 0]); //что выгодней - положить или нет?
                    }
                }
            }
            Console.Write("РЕЗУЛЬТАТ: " + bp[w]);
        }

        static void Task2()
        {
            Console.Write("\nВведите количество вещей: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите вместимость рюкзака: ");
            int w = int.Parse(Console.ReadLine());

            a = new int[n, 2];
            Console.WriteLine("\nВведите попарно стоимость и вес каждого предмета\n" +
                "(Сначала введите стоимость предмета, а затем через Enter его вес)");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Предмет " + (i + 1) + ":");
                for (int j = 0; j < 2; j++)
                {
                    a[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            int[,] bp = new int[n + 1, w + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    if (a[i - 1, 1] <= j)
                    {
                        bp[i, j] = Math.Max(a[i - 1, 0] + bp[i - 1, j - a[i - 1, 1]], bp[i - 1, j]);
                        //if (bp[i - 1, j - a[i - 1, 0]] + a[i - 1, 1] > bp[i, j]) //что выгодней - положить или нет?
                        //{
                        //    bp[i, j] = bp[i - 1, j - a[i - 1, 0]] + a[i - 1, 1];
                        //}
                    }
                    else
                        bp[i, j] = bp[i - 1, j];
                }
            }
            Console.WriteLine();
            Console.Write("РЕЗУЛЬТАТ: " + bp[n, w]);
        }

        static void Main(string[] args)
        {
            char key;
            do
            {
                Console.Clear();    
                Console.Write(
                    "Выберите пункт меню:\n" +
                    "0 - Выход\n" +
                    "1 - Рюкзак с повторениями\n" +
                    "2 - Рюкзак без повторений\n\n" +
                    "Ваш выбор: ");
                key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '0':
                        break;
                    case '1':
                        Task1();
                        break;
                    case '2':
                        Task2();
                        break;
                    default:
                        Console.WriteLine("Некорректный пункт меню");
                        break;
                }
                Console.ReadLine();
            }
            while (key != '0');
        }
    }
}
