using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    public static class ArrayHelper
    {
        public static bool UsuallyFindElem(this double[] Arr, double findElem)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i].Equals(findElem)) return true;
            }
            return false;
        }

        public delegate bool Function(double elem1, double elem2);

        public static bool DelegateFindElem(this double[] Arr, double findElem, Function f)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                if (f(Arr[i],findElem)) return true;
            }
            return false;
        }

        public static bool LINQFindElem(this double[] Arr, double findElem)
        {
            var foundElem = from item in Arr
                            where item.Equals(findElem)
                            select item;
            if (foundElem.Equals(findElem)) return true;
            else return false;
        }
    }
}
