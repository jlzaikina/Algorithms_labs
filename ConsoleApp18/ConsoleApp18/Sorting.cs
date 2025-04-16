using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Sorting
    {
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static int Partition(int[] arr, int low, int high)
        {
            Random rand = new Random();
            int randomIndex = rand.Next(low, high);
            int pivot = arr[randomIndex];
            Swap(arr, randomIndex, high);

            int i = low - 1;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);

            return i + 1;
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public static void ShakerSort(int[] arr)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(arr, i, i + 1);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    if (arr[i - 1] > arr[i])
                        Swap(arr, i - 1, i);
                }
                left++;
            }
        }
    }
}
