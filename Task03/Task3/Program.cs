using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;
            Stopwatch sw1= new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            sw1.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            sw1.Stop();

            sw2.Start();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            sw2.Stop();

            Console.WriteLine("Время затраченное на простое сложение строк : {0}", sw1.ElapsedTicks);
            Console.WriteLine("Время затраченное на стрингбилдер : {0}", sw2.ElapsedTicks);
            Console.WriteLine("Второй способ быстрее в {0} раз", (sw1.ElapsedTicks / sw2.ElapsedTicks));
            Console.ReadKey();
        }
    }
}
