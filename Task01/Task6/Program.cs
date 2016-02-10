using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            int bold = 0;
            int italic = 0;
            int underline = 0;

            int Key;
            string stringStyle = "";

            while (true)
            {
                stringStyle = "";
                if ((bold == 0) && (italic == 0) && (underline == 0)) stringStyle = "None";
                else
                {
                    if (bold == 1) stringStyle += "bold";
                    if (italic == 1) stringStyle += ", italic";
                    if (underline == 1) stringStyle += ", underline";
                    if (stringStyle[0] == ',') stringStyle = stringStyle.Remove(0,2); //Удаляем ненужную запятую и пробел в начале строки
                }
                Console.WriteLine("Параметры надписи: {0}", stringStyle);
                Console.WriteLine("Введите: \r\n 1:bold \r\n 2:italic \r\n 3:underline");
                Key = int.Parse(Console.ReadLine());
                if (Key == 1)
                {
                    if (bold == 0) bold = 1;
                    else bold = 0;
                }
                if (Key == 2)
                {
                    if (italic == 0) italic = 1;
                    else italic = 0;
                }
                if (Key == 3)
                {
                    if (underline == 0) underline = 1;
                    else underline = 0;
                }
            }
        }
    }
}
