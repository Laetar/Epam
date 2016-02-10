using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ArrLength = 20;
            int[] Arr = new int[ArrLength];

            rndArr(ref Arr);
            Console.WriteLine("Массив:");
            WriteArr(Arr);
            Console.WriteLine("Сумма положительных элементов:{0}",ArrSum(Arr));
            Console.ReadKey();
        }

        static private void rndArr(ref int[] Arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rnd.Next(-100, 100);
            }
        }

        static private int ArrSum (int[] Arr)
        {
            int summ = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] > 0) summ += Arr[i];
            }
            return summ;
        }

        static private void WriteArr(int[] Arr)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write(Arr[i] + ",");
            }
            Console.WriteLine();
        }
    }
}
