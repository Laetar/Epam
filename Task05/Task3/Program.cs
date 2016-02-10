using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        private static Line Line;
        private static Round Round;
        private static Ring Ring;
        private static Rectangle Rectangle;

        static void Main(string[] args)
        {
            StartUI();
        }

        private static void StartUI ()
        {
            Console.WriteLine("Выберите пункт");
            Console.WriteLine("1 - Создать/изменить Линию");
            Console.WriteLine("2 - Создать/изменить Круг ");
            Console.WriteLine("3 - Создать/изменить Кольцо ");
            Console.WriteLine("4 - Создать/изменить Прямоугольник ");
            Console.WriteLine("5 - Вывести информацию о созданных фигурах");
            int i;
            int.TryParse(Console.ReadLine(),out i);
            switch (i)
            {
                case 1:
                    {
                        CreateLine();
                        break;
                    }
                case 2:
                    {
                        CreateRound();
                        break;
                    }
                case 3:
                    {
                        CreateRing();
                        break;
                    }
                case 4:
                    {
                        CreateRectangle();
                        break;
                    }
                case 5:
                    {
                        WriteFigure();
                        break;
                    }
            }
        }

        private static void CreateLine()
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;
            Console.WriteLine("Введите координату X у первой точки");
            double.TryParse(Console.ReadLine(), out x1);
            Console.WriteLine("Введите координату Y у первой точки");
            double.TryParse(Console.ReadLine(), out y1);
            Console.WriteLine("Введите координату X у второй точки");
            double.TryParse(Console.ReadLine(), out x2);
            Console.WriteLine("Введите координату Y у второй точки");
            double.TryParse(Console.ReadLine(), out y2);
            Line = new Line(x1, y1, x2, y2);
            Console.WriteLine("Линия создана/изменена");
            Console.WriteLine("---------------------------------------");
            StartUI();
        }

        private static void CreateRound()
        {
            Point p = new Point();
            double r;
            Console.WriteLine("Введите координату центра х");
            double.TryParse(Console.ReadLine(), out p.x);
            Console.WriteLine("Введите координату центра y");
            double.TryParse(Console.ReadLine(), out p.y);
            Console.WriteLine("Введите радиус круга");
            double.TryParse(Console.ReadLine(), out r);
            Round = new Round(p.x, p.y, r);
            Console.WriteLine("Круг создан/изменен");
            Console.WriteLine("---------------------------------------");
            StartUI();
        }

        private static void CreateRing()
        {
            Point p = new Point();
            double r1;
            double r2;
            Console.WriteLine("Введите координату центра х");
            double.TryParse(Console.ReadLine(), out p.x);
            Console.WriteLine("Введите координату центра y");
            double.TryParse(Console.ReadLine(), out p.y);
            Console.WriteLine("Введите радиус первого круга круга");
            double.TryParse(Console.ReadLine(), out r1);
            Console.WriteLine("Введите радиус второго круга круга");
            double.TryParse(Console.ReadLine(), out r2);
            Ring = new Ring(p.x, p.y, r1, r2);
            Console.WriteLine("Кольцо созданно/изменено");
            Console.WriteLine("---------------------------------------");
            StartUI();
        }

        private static void CreateRectangle()
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;
            Console.WriteLine("Введите координату X у первой угловой точки прямоугольника");
            double.TryParse(Console.ReadLine(), out x1);
            Console.WriteLine("Введите координату Y у первой угловой точки прямоугольника");
            double.TryParse(Console.ReadLine(), out y1);
            Console.WriteLine("Введите координату X у второй угловой точки прямоугольника");
            double.TryParse(Console.ReadLine(), out x2);
            Console.WriteLine("Введите координату Y у второй угловой точки прямоугольника");
            double.TryParse(Console.ReadLine(), out y2);
            Rectangle = new Rectangle(x1, y1, x2, y2);
            Console.WriteLine("Прямоугольник создан/изменен");
            Console.WriteLine("---------------------------------------");
            StartUI();
        }

        private static void WriteFigure()
        {
            Console.WriteLine("---------------------------------------");
            if (!Line.IsNull())
            {
                Console.WriteLine("Параметры линии: ");
                Console.WriteLine("Координаты точек A и B: A({0},{1}),B({2},{3})", Line.x1,Line.y1,Line.x2,Line.y2);
                Console.WriteLine("Длинна отрезка AB: {0}", Math.Round(Line.Length()));
                Console.WriteLine();
            }
            if (!Round.IsNull())
            {
                Console.WriteLine("Параметры круга: ");
                Console.WriteLine("Координата центра круга: ({0},{1}), Радиус круга {2}", Round.X, Round.Y, Round.Radius);
                Console.WriteLine("Площадь круга: {0}", Math.Round(Round.Area()));
                Console.WriteLine("Периметр круга: {0}", Math.Round(Round.Length()));
                Console.WriteLine();
            }
            if (!Ring.IsNull())
            {
                Console.WriteLine("Параметры кольца: ");
                Console.WriteLine("Координата центра кольца: ({0},{1})", Ring.inRound.X, Ring.inRound.Y);
                Console.WriteLine("Радиус внешнего круга: {0}, Радиус внутреннего круга: {1}",Ring.outRound.Radius,Ring.inRound.Radius);
                Console.WriteLine("Площадь кольца: {0}", Math.Round(Ring.Area()));
                Console.WriteLine("Периметр кольца: {0}", Math.Round(Ring.SumLength()));
                Console.WriteLine();
            }
            if (!Rectangle.IsNull())
            {
                Console.WriteLine("Параметры прямоугольника: ");
                Console.WriteLine("Координаты угловых точек прямоугольника: A({0},{1}),B({2},{3})", Rectangle.x1, Rectangle.y1, Rectangle.x2, Rectangle.y2);
                Console.WriteLine("Периметр прямоугольника: {0}", Rectangle.Length());
                Console.WriteLine("Площадь прямоугольника: {0}", Rectangle.Area());
                Console.WriteLine();
            }
            Console.ReadKey();

        }

    }
}
