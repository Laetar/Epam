using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int x = 5;
            const int y = 5;
            const int z = 5;
            int[,,] Arr = new int[x, y, z];

            RndArr(ref Arr, x, y, z);
            Console.WriteLine("Массив до...");
            WriteArr(Arr, x, y, z);
            NullArr(ref Arr, x, y, z);
            Console.WriteLine("Массив после...");
            WriteArr(Arr, x, y, z);
            Console.ReadKey();
        }

        static private void RndArr(ref int[,,] Arr, int x, int y, int z)
        {
            Random rnd = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        Arr[i, j, k] = rnd.Next(-100, 100);
                    }
                }
            }

        }

        static private void WriteArr (int[,,] Arr,int x,int y,int z)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        Console.Write(Arr[i, j, k]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static private void NullArr (ref int[,,] Arr,int x,int y,int z)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    for (int k = 0; k < z; k++)
                    {
                        if (Arr[i, j, k] < 0) Arr[i, j, k] = 0;
                    }
                }
            }
        }
    }
}
