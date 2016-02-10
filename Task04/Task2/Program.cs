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
            Triangle t = new Triangle();
            Console.WriteLine("Введите стороны триугольника:");
            ReadTriange(ref t);
            Console.WriteLine("Площадь треуголника : {0}", Math.Round(t.Area()));
            Console.WriteLine("Периметр треуголника :{0}", Math.Round(t.Perimeter()));
            Console.ReadKey();

        }

        private static void ReadTriange(ref Triangle t)
        {
            double res;
            Console.WriteLine();
            Console.WriteLine("Сторона a:");
            if (double.TryParse(Console.ReadLine(), out res)) t.a = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 1");
                t.a = 1;
            }
            Console.WriteLine("Сторона b:");
            if (double.TryParse(Console.ReadLine(), out res)) t.b = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 1");
                t.b = 1;
            }
            Console.WriteLine("Сторона c:");
            if (double.TryParse(Console.ReadLine(), out res)) t.c = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 1");
                t.c = 1;
            }
        }
    }
}
