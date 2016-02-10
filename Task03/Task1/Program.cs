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
            Console.WriteLine("Введите распознаваемую строку");
            string str = Console.ReadLine();
            Console.WriteLine("Средняя длина слова в введенной строке равна : {0}",MiddleStr(str));
            Console.ReadKey();
        }

        static private double MiddleStr(string str)
        {
            int Summ = 0;
            double Middle = 0;
            char[] separator = { ' ', ',', '.', ':', '?', '!', '[', ']', '(', ')', '{', '}', '’', '\'', '‒', '–', '—', '―','‐', '-', '„', '“', '«', '»', '“', '”', '‘', '’', '‹', '›','"' };
            string[] WordsArr = str.Split(separator);
            foreach(string elem in WordsArr)
            {
                Summ += elem.Length;
            }
            Middle = (double)Summ / WordsArr.Length;
            return Math.Round(Middle);
        }
    }
}