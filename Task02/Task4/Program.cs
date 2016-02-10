using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            const int x = 5;
            const int y = 5;
            int sum = 0;
            int[,] Arr = new int[x,y];

            RndArr(ref Arr, x, y);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if ((i + j) % 2 == 0) sum += Arr[i, j];
                }
            }
            Console.WriteLine("Массив:");
            WriteArr(Arr,x,y);
            Console.WriteLine("Сумма четных элементов массива: {0}", sum);
            Console.ReadKey();
        }

        static private void RndArr(ref int[,] Arr, int x, int y)
        {
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Arr[i, j] = rnd.Next(0, 5);
                }
            }

        }

        static private void WriteArr(int[,] Arr, int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(Arr[i, j] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
