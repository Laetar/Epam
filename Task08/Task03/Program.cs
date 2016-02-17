using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            const int findElem = 40;
            bool a;
            bool b;
            bool c;
            bool d;
            bool e;
            long aTime;
            long bTime;
            long cTime;
            long dTime;
            long eTime;

            Stopwatch stopWatch = new Stopwatch();
            Random rdm = new Random();
            double[] DoubleArr = new double[100];
            for (int i = 0; i < 100; i++)
            {
                DoubleArr[i] = rdm.Next();
            }

            int j = 0;

            //Normal
            stopWatch.Start();
            for (j = 0; j < 10; j++)
            {
                a = DoubleArr.UsuallyFindElem(findElem);
            }
            stopWatch.Stop();
            aTime = stopWatch.ElapsedTicks;

            //Normal delegate
            stopWatch.Restart();
            for (j = 0; j < 10; j++)
            {
                b = DoubleArr.DelegateFindElem(findElem, IsTheSame);
            }
            stopWatch.Stop();
            bTime = stopWatch.ElapsedTicks;

            //Anonim delegate
            stopWatch.Restart();
            for (j = 0; j < 10; j++)
            {
                c = DoubleArr.DelegateFindElem(findElem, delegate (double elem1, double elem2)
                {
                    if (elem1.Equals(elem2)) return true;
                    else return false;
                });
            }
            stopWatch.Stop();
            cTime = stopWatch.ElapsedTicks;

            //Lambda delegate
            stopWatch.Restart();
            for (j = 0; j < 10; j++)
            {
                d = DoubleArr.DelegateFindElem(findElem, (x,y) => x == y);
            }
            stopWatch.Stop();
            dTime = stopWatch.ElapsedTicks;

            //LINQ
            stopWatch.Restart();
            for (j = 0; j < 10; j++)
            {
                e = DoubleArr.LINQFindElem(10);
            }
            stopWatch.Stop();
            eTime = stopWatch.ElapsedTicks;

            Console.WriteLine("Время затраченное на обычный способ: {0}", aTime);
            Console.WriteLine("Время затраченное на обычный делегатный способ: {0}", bTime);
            Console.WriteLine("Время затраченное на Анонимный делегатный способ: {0}", cTime);
            Console.WriteLine("Время затраченное на способ на лямбда-выражених: {0}", dTime);
            Console.WriteLine("Время затраченное на LINQ способ способ: {0}", eTime);
            Console.ReadKey();
        }

        private static bool IsTheSame(double elem1, double elem2)
        {
            if (elem1.Equals(elem2)) return true;
            else return false;
        }

    }
}
