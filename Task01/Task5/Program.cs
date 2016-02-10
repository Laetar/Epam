using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1000;
            int b = 0;

            for (int i = 0; i < a; i++)
            {
                if ((i % 3 == 0) || (i % 5 == 0))  b+= i;
            }
            Console.WriteLine("Сумма чисел кратных 3 и 5 но меньше 1000 равна : {0}", b);
            Console.ReadKey();
        }
    }
}
