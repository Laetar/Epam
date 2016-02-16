using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public static class StrComp
    {
        public delegate bool Function(string str1, string str2);

        public static bool CompareStr(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return true;
            }
            else if (str1.Length == str2.Length)
            {
                int i;
                for (i = 0; i < str1.Length; i++)
                {
                    if (str1[i] > str2[i]) return true;
                }
                return false;
            }
            else return false;
        }

        public static string[] SortStr(string[] ArrStr, Function f)
        {
            string _str;
            int i;
            int j;
            for (i = 0; i < ArrStr.Length - 1; i++)
            {
                for (j = 0; j < ArrStr.Length - i - 1; j++)
                {
                    if (f(ArrStr[j], ArrStr[j + 1]))
                    {
                        _str = ArrStr[j + 1];
                        ArrStr[j + 1] = ArrStr[j];
                        ArrStr[j] = _str;
                    }
                }
            }
            return ArrStr;
        }
    }
}
