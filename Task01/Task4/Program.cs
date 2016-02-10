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
            int a;
            int b = 0;
            int colStar;

            Console.WriteLine("Введите колличество триугольников:");
            a = int.Parse(Console.ReadLine());

            while (b < a)
            {
                b++;
                colStar = 1;
                double collSpace = a;
                for (int i = 0; i < b; i++)
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
                    colStar += 2;
                    collSpace--;
                }
            }
            Console.ReadKey();
        }
    }
}
