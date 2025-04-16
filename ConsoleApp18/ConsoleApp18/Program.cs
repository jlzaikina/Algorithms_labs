
using ConsoleApp18;
using System;
using System.Diagnostics;

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        for (int i = 0; i < 6; i++)
        {
            int N = rnd.Next(1000, 100000);
            int[] arr = new int[N];
            int[] arr1 = new int[N];
            Console.WriteLine();
            Console.WriteLine("\nРазмер массива N = " + N);
            for (int j = 0; j < N; j++)
            {
                arr[j] = rnd.Next(-1000, 1000);
                arr1[j] = arr[j];
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Restart(); // Начало отсчета времени
            Sorting.QuickSort(arr, 0, arr.Length - 1);
            stopwatch.Stop(); // Конец отсчета времени
            Console.WriteLine("Quick Sort с случайным опорным элементом выполнен за {0} миллисекунд", stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            Sorting.ShakerSort(arr1);
            stopwatch.Stop();
            Console.WriteLine("Sheiker Sort  выполнен за {0} миллисекунд", stopwatch.ElapsedMilliseconds);
        }
    }
}
