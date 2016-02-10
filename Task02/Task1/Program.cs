using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сергеев_Никита_Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ArrLength = 20;
            int[] Arr = new int[ArrLength];
            Random rnd = new Random();

            rndArr(ref Arr);

            //Выводим массив
            Console.WriteLine("Массив до");
            WriteArr(Arr);
            Bubblesort(ref Arr);
            Console.WriteLine("Массив после");
            WriteArr(Arr);
            Console.WriteLine("Max:{0} and Min:{1}", Arr[0], Arr[Arr.Length-1]);
            Console.ReadKey();
        }

        //Вывод на консоль
        static private void WriteArr (int[] Arr)
        {
            for (int i = 0;i< Arr.Length; i++)
            {
                Console.Write(Arr[i] + ",");
            }
            Console.WriteLine();
        }

        static private void Bubblesort(ref int[] Arr)
        {
            int a;
            for (int i = 0; i < Arr.Length - 1; i++)
            {
                for (int j = 0; j < Arr.Length - i - 1; j++)
                {
                    if (Arr[j] < Arr[j + 1])
                    {
                        a = Arr[j];
                        Arr[j] = Arr[j + 1];
                        Arr[j + 1] = a;
                    }
                }
            }
        }

        static private void rndArr (ref int[] Arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr[i] = rnd.Next(-100, 100);
            }
        }
    }
}
