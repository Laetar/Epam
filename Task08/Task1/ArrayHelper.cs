using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class ArrayHelper
    {
        public static double HelperSum(this IEnumerable<double> Arr)
        {
            double summ = 0;
            foreach(double elem in Arr)
            {
                summ += elem;
            }
            return summ;
        }
    }
}
