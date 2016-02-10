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
            Round c1 = new Round();
            Round c2 = new Round();

            Console.WriteLine("Введите данные первого круга:");
            ReadRound(ref c1);
            Console.WriteLine("Введите данные второго круга:");
            ReadRound(ref c2);
            Console.WriteLine(Contact(c1, c2));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Площадь первого круга : {0} Площадь второго круга: {1}", Math.Round(c1.Area()), Math.Round(c2.Area()));
            Console.WriteLine();
            Console.WriteLine("Периметр первого круга : {0} Периметр второго круга: {1}", Math.Round(c1.Length()), Math.Round(c2.Length()));
            Console.ReadKey();

        }

        static private string Contact (Round c1, Round c2)
        {
            double distance = Math.Sqrt((Math.Pow((c1.X - c2.X), 2) + Math.Pow((c1.Y - c2.Y), 2)));
            double sumR = c1.Radius + c2.Radius;
            if ((distance < sumR) && ((sumR - distance) > Math.Min(c1.Radius, c2.Radius))) return ("Один круг лежит внутри другого");
            else if ((distance < sumR)) return ("У кругов есть общий сектор");
            else if (distance == sumR) return ("Круги соприкосаются");
            else return ("Круги не соприкосаются");
        }

        static private void ReadRound (ref Round c)
        {
            double res;
            Console.WriteLine("Введите координату X круга");
            if (double.TryParse(Console.ReadLine(), out res)) c.X = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 0");
                c.X = 0;
            }
            Console.WriteLine("Введите координату Y круга");
            if (double.TryParse(Console.ReadLine(), out res)) c.Y = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 0");
                c.Y = 0;
            }
            Console.WriteLine("Введите радиус R круга");
            if (double.TryParse(Console.ReadLine(), out res)) c.Radius = res;
            else
            {
                Console.WriteLine("Вы ввели неверное значение, теперь это просто 0");
                c.Radius = 0;
            }
            Console.WriteLine();
        }
    }
}
