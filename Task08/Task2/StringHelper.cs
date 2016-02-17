using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class StringHelper
    {
        public static bool HelperIsNumber(this string str)
        {
            foreach (char elem in str)
            {
                if (!Char.IsDigit(elem)) return false;
            }
            return true;
        }
    }
}
