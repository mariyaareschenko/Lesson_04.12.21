using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 2, 5, 4, 6, 8, 7, 1, 9 };
            int[] array2 = { 45,56,7,8,56 };
            int[] array3 = { 4, 89, 14, 36 };
            int[] array4 = { 2, 71, 65, 78 };
            int[] array5 = { 12, 11, 13, 5, 7, 4 };
            Console.WriteLine("Сортировка пузырька с флагом");
            bool flag = true;
            int i = 0;
            while (flag)
            {
                flag = false;
                for (int j = 0; j < array.Length-i-1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                }
                i++;
            }
            for(int j = 0; j < array.Length; j++)
            {
                Console.WriteLine(array[j]);
            }
            Console.WriteLine("Сортировка выбором");
            ViborSort(array2);
            for (int j = 0; j < array2.Length; j++)
            {
                Console.WriteLine(array2[j]);
            }

            Console.WriteLine("Сортировка вставками");
            SortByInserts(array3);
            for (int j = 0; j < array3.Length; j++)
            {
                Console.WriteLine(array3[j]);
            }

            Console.WriteLine("Сортировка вставками с барьером");
            SortBarrier(array4);
            for (int j = 0; j < array4.Length; j++)
            {
                Console.WriteLine(array4[j]);
            }

            Console.WriteLine("Сортировка бинарными вставками");
            for (int j = 0; j < array2.Length; j++)
            {
                Console.WriteLine(array2[j]);
            }

            Console.WriteLine("Пирамидальная сортировка");
            HeapSort heap = new HeapSort();
            heap.Sort(array5);
            heap.Print(array5);
            Console.ReadKey();
        }
        static int[] ViborSort(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int min = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if(array[j]< array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[min];
                array[min] = array[i];
                array[i] = temp;
            }
            return array;
        }
        static int[] SortByInserts(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                var key = array[j];
                var k = j;
                while((k>1) && (array[k - 1] > key))
                {
                    Swap(ref array[k - 1], ref array[k]);
                    k--;
                }
                array[k] = key;
            }
            return array;
        }
        static int[] SortBarrier(int[] array)
        {
            for (int j = 2; j < array.Length; j++)
            {
                if (array[j - 1] > array[j])
                {
                    array[0] = array[j];
                    int k = j - 1;
                    while (array[k] > array[0])
                    {
                        array[k + 1] = array[k];
                        k--;
                    }
                    array[k + 1] = array[0];
                }
            }
            return array;
        }
        static int[] BinarySort(int [] array)
        {
            for(int j = 2; j < array.Length; j++)
            {
                if (array[j - 1] > array[j])
                {
                    int k = array[j];
                    int pos = -1;
                    int start = 0;
                    int end = j - 1;
                    while(start <= end && !(pos != -1))
                    {
                        int middle = (start + end) / 2;
                        if(k > array[middle])
                        {
                            end = middle - 1;
                        }
                        else
                        {
                            pos = middle;
                        }
                    }
                    if (end < 0)
                    {
                        pos = 0;
                    }
                    else if (start >= j)
                    {
                        pos = j;
                    }
                    if(pos < j)
                    {
                        for(int l = j; l> pos; l--)
                        {
                            array[l] = array[l - 1];
                        }
                        array[pos] = k;
                    }
                }
            }
            return array;
        }
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}
