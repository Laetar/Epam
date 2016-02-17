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
            List<double> ElemList = new List<double>();
            double n = 0;
            int i = 1;
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите {0} число массива.(Ведите НЕ число чтобы остановиться)", i);
                if (!double.TryParse(Console.ReadLine(), out n)) repeat = false;
                i++;
                ElemList.Add(n);
            }
            double[] A = ElemList.ToArray();
            Console.WriteLine("Сумма элементов массива: {0}",A.HelperSum());
            Console.ReadKey();
        }
    }
}
