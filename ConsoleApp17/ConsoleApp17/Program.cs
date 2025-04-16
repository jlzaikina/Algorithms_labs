using ConsoleApp17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR
{
    class Program
    {

        //Задание 1. Дана строка со скобками. Проверьте правильность расстановки скобок за время О(n).
        //а) в строке содержатся только круглые скобки;
        //б) скобки могут быть любые.
        static bool Round(string s) //сложность O(n) 
        {
            int open = 0;
            int close = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                   open++;
                }
                else if ((s[i] == ')'))
                {
                    close++;
                }
                else { return false; }
            }
            if (open != close)
            {
                return false;
            }
            return true;
        }

        static bool Different(string s) //сложность O(n) 
        {
            string add = "";
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {         
                    case '(':
                        {
                            add += ')';
                            break;
                        };
                    case '[':
                        {
                            add += ']';
                            break;
                        };
                    case '{':
                        {
                            add += '}';
                            break;
                        }
                    case ')':
                        {
                            if (add[add.Length - 1] != ')')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    case ']':
                        {
                            if (add[add.Length - 1] != ']')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    case '}':
                        {
                            if (add[add.Length - 1] != '}')
                            {
                                return false;
                            }
                            add = add.Remove(add.Length - 1);
                            break;
                        }
                    default: return false;
                }
            }
            return true;
        }

        //Задание 3. Задача «Поддержания max в окне». Дан массив размером n и счетчик k, определяющий размер окна в массиве.Окно двигается от
        //начала до конца массива.Необходимо найти максимум в окне и напечатать все их значения.
        static int[] FindMax(int[] arr, int k) //сложность O(n) 
        {
            int n = arr.Length;
            var B = new int[n]; // будем хранить максимум на промежутке от начала текущего блока до i-го элемента;
            var C = new int[n]; //будем хранить максимум на промежутке от i-го элемента до конца текущего блока.
            B[0] = arr[0];
            C[n - 1] = arr[n - 1];

            k--;

            for (int i = 1, j = n - 2; i < n; i++, j--)
            {
                if (i % k != 0)
                {
                    B[i] = Math.Max(arr[i], B[i - 1]);
                }
                else
                {
                    B[i] = arr[i];
                }


                if ((j + 1) % k != 0)
                {
                    C[j] = Math.Max(arr[j], B[j + 1]);
                }
                else
                {
                    C[j] = arr[j];
                }
            }

            var maxArr = new int[n - k];
            for (int i = 0; i < n - k; i++)
            {
                maxArr[i] = Math.Max(C[i], B[i + k]);
            }
            return maxArr;
        }

        //Задание 4. Дан массив размера n+1. Элементы массива числа из множества {1, 2, 3 … n}. Найдите повторяющееся число за время О(n), не
        //используя дополнительной памяти. Повторяющихся элементов может быть несколько.
        static void Find(int[] arr)//сложность O(n) 
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[Math.Abs(arr[i])] > 0)
                { 
                    arr[Math.Abs(arr[i])] *= -1;
                }
                else 
                {
                    Console.Write(Math.Abs(arr[i]) + " ");
                }
            }
        }
        //Задание 5. Обнулите столбец N и строку M матрицы, если элемент в ячейке(N, M) нулевой.

        static int[,] Zero(int[,] matrix)           //сложность O(n*m) 
        {
            bool[] row = new bool[matrix.GetLength(0)];
            bool[] column = new bool[matrix.GetLength(1)];

            //ищем нули в элементах матрицы и заполняем массивы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row[i] = true;
                        column[j] = true;
                    }
                }
            }

            //зануляем строки и столбцы согласно заполненным массивам
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (row[i] || column[j])
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 0;
            while (true)
            {
                Console.WriteLine("Выберите задание: \n 0) Выход \n 1) Проверка правильности расстановки скобок \n 2) Push/pop и min " +
                    "\n 3) Поддержание max в окне \n 4) Нахождение повторяющегося числа" +
                    "\n 5) Обнуление строк матрицы ");
                Console.Write("Ваш выбор: ");
                string selected = Console.ReadLine();
                Console.WriteLine();
                switch (selected)
                {
                    case "0": return;
                    case "1":
                        {
                            Console.WriteLine("Введите строку: ");
                            string str = Console.ReadLine();
                            Console.WriteLine("Выберите тип скобок в строке: \n а)Только круглые  \n б)Любые");
                            char c = char.Parse(Console.ReadLine());
                            switch (c)
                            {
                                case 'а':
                                    {
                                        if (Round(str))
                                        {
                                            Console.WriteLine("Скобки расставлены верно.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Скобки расставлены не верно.");
                                        }
                                        break;
                                    }
                                case 'б':
                                    {
                                        if (Different(str))
                                        {
                                            Console.WriteLine("Скобки расставлены верно.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Скобки расставлены не верно.");
                                        }
                                        break;
                                    }
                                default: Console.WriteLine("Введено не верное значение."); break;
                            }
                            break;
                        }
                    case "2":
                        {
                            MinStack stack = new MinStack();
                            stack.Push(3);
                            stack.Push(2);
                            stack.Push(4);
                            stack.Push(1);

                            Console.WriteLine(stack.Min()); // 1

                            stack.Pop();
                            stack.Pop();

                            Console.WriteLine(stack.Min()); // 2
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите длину массива:");
                            count = int.Parse(Console.ReadLine());
                            int[] arr = new int[count];
                            Console.WriteLine("Исходный массив: ");
                            for (int i = 0; i < count; i++)
                            {
                                arr[i] = random.Next(1, 10);
                                Console.Write(arr[i] + " ");
                            }
                            Console.WriteLine("Введите размер окна:");
                            int k = int.Parse(Console.ReadLine());
                            arr = FindMax(arr, k);
                            Console.WriteLine("Mаксимумы в окне: ");
                            for (int i = 0; i < arr.Length; i++)
                            {
                                Console.Write(arr[i] + " ");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Введите длину массива:");
                            count = int.Parse(Console.ReadLine());
                            int[] arr = new int[count];
                            Console.WriteLine("Исходный массив: ");
                            for (int i = 0; i < count; i++)
                            {
                                arr[i] = random.Next(1, count);
                                Console.Write(arr[i] + " ");
                            }
                            Console.WriteLine();
                            Find(arr);
                            break;
                        }    
                    case "5":
                        {
                            Console.WriteLine("Введите кол-во строк в матрице: ");
                            int n = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите кол-во столбцов в матрице: ");
                            int m = int.Parse(Console.ReadLine());

                            int[,] matrix = new int[n, m];
                            Console.WriteLine("Исходная матрица: ");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {
                                    matrix[i, j] = random.Next(-10, 10);
                                    Console.Write("{0}\t", matrix[i, j]);
                                }
                                Console.Write("\n");
                            }
                            matrix = Zero(matrix);
                            Console.WriteLine("Новая матрица: ");
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {
                                    Console.Write("{0}\t", matrix[i, j]);
                                }
                                Console.Write("\n");
                            }
                            break;
                        }
                    default: Console.WriteLine("Введено не верное значение"); break;
                }
                Console.WriteLine("\r\nДля возврата в меню нажмите Enter. Для выхода нажмите 0.");
                Console.Write("Ваш выбор: ");
                string s = Console.ReadLine();
                if (s == "0")
                    return;
                else
                    Console.Clear();
            }
        }
    }
}