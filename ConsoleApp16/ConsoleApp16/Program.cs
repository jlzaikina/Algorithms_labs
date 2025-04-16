

using ConsoleApp16;
using System;

class Programm
{
    static void Main(string[] args)
    {
        Class1 c = new Class1();
        while (true)
        {
            Console.Write("Введите a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            int b = int.Parse(Console.ReadLine());
            if (a < 0 && b < 0)
            {
                Console.WriteLine("Наибольшее: " + c.MaximumNeg(a, b));
            }
            else
            {
                Console.WriteLine("Наибольшее: " + c.Maximum(a, b));
            }
            Console.WriteLine("Наибольшее: " + c.getMax(a, b));
        }
    }
}