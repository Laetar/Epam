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
            Console.WriteLine("Введите распознаваемую строку");
            string str1 = Console.ReadLine();
            Console.WriteLine("Ключевую строку");
            string str2 = Console.ReadLine();
            Console.WriteLine("Полученная строка: {0}", DoubleChar(str1, str2));
            Console.ReadKey();

        }

        static private string DoubleChar(string str1, string str2)
        {
            int x = 0;
            int y = 0;
            char[] letter = new char[str1.Length];
            str2 = str2.Replace(" ", "");
            letter = str2.ToCharArray().Distinct().ToArray();
            for (int i = 0; i < letter.Length; i++)
            {
                x = 0;
                y = 0;
                while ((x < str1.Length) && (x >= 0))
                {
                    x = str1.IndexOf(letter[i], y);
                    if (x !=-1) str1 = str1.Insert(x + 1, Char.ToString(letter[i]));
                    y = x + 2;
                }
            }
            return str1;
        }
    }
}
