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
            string A;
            Console.WriteLine("Введите строку, проверяемую на число.");
            A = Console.ReadLine();
            Console.WriteLine("Это положительное целое число? Ответ: {0}", A.HelperIsNumber());
            Console.ReadKey();
        }
    }
}
