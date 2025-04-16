using ConsoleApp15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    //Задание 1.
    static void Find()
    {
        LinkedList list = new LinkedList();
        Random rand = new Random();
        for (int i = 0; i < 8; i++)
        {
            list.Add(rand.Next(1, 70));
        }
        Console.WriteLine("Список: ");
        Console.WriteLine(list.ToString());
        list.head.Next.Next.Next.Next.Next.Next.Next.Next = list.head.Next.Next;
        Console.WriteLine("Начало петли - узел со значением: " + list.Find(list.head).El);
        Console.WriteLine();
    }
    //Задание 2. 
    static void Copy()
    {
        DoubleLink list = new DoubleLink();
        Random rand = new Random();
        for (int i = 0; i < 8; i++)
        {
            list.Add(rand.Next(1, 20));
        }
        Console.WriteLine("Начальный список: ");
        list.PrintList(list.head);
        Console.WriteLine();
        Console.WriteLine("Скопированный список: ");

        //ConsoleApp15.LinkedList<int> originalList = new ConsoleApp15.LinkedList<int>();
        //originalList.Add(2);
        //originalList.Add(7);
        //originalList.Add(8);

        //originalList.PrintList(originalList.head);

        //Node<int> newList = originalList.CopyList();
        //originalList.PrintList(newList);

        Node newList = list.CopyList(list.head);
        list.PrintList(newList);
    }

    //Задание 3.
    static void Delete()
    {
        LinkedList list = new LinkedList();
        Random rand = new Random();
        for (int i = 0; i < 8; i++)
        {
            list.Add(rand.Next(1, 15));
        }
        Console.WriteLine("Начальный список: \n" + list.ToString());
        list.Delete(list.head);
        Console.WriteLine("Список без дубликатов: \n" + list.ToString());
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задание: \n 0)Выход \n 1) Нахождение начала петли \n 2) Копирование двусвязного списка " +
                "\n 3) Удаление дубликатов");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "0": return;
                case "1": Find(); break;
                case "2": Copy(); break;
                case "3": Delete(); break;  
                default: Console.WriteLine("Неверный формат"); break;
            }
            Console.WriteLine("\r\nДля возврата в меню нажмите Enter. Для выхода нажмите 0.");
            Console.Write("Ваш выбор: ");
            string pnt = Console.ReadLine();
            if (pnt == "0")
                return;
            else
                Console.Clear();
        }
    }
}
