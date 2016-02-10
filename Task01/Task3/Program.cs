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
            int a;
            int colStar = 1;

            Console.WriteLine("Введите колличество строк в триугольнике:");
            a = int.Parse(Console.ReadLine());


            double collSpace = a;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < collSpace; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < colStar; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                colStar +=2;
                collSpace--;
            }
            Console.ReadKey();
        }
    }
}
