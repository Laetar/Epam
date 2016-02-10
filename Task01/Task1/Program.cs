using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;

            do
            {
                Console.WriteLine("Введите сторону прямоугольника а:");
                a = int.Parse(Console.ReadLine());
            } while (!Check(a));

            do
            {
                Console.WriteLine("Введите сторону прямоугольника b:");
                b = int.Parse(Console.ReadLine());
            } while (!Check(b));

            Console.WriteLine("Площадь прямоугольника ab равна:{0}",a*b);
            Console.ReadKey();
        }

        static bool Check (int a)
        {
            bool b = true;
            if (a <= 0)
            {
                b = false;
                Console.WriteLine("Введено неверное значение.");
                Console.WriteLine();
            }
            return b;
        }
    }
}
