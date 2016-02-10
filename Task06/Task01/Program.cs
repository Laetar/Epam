using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            LinkElem<int> head = new LinkElem<int>();

            Console.WriteLine("Введите колличество человек");
            while (!int.TryParse(Console.ReadLine(), out n)) ;
            Console.WriteLine();

            CreateCircleOfElem(n,ref head);
            CircleDelete(ref head);

            Console.WriteLine("Остался элемент под номером {0}", head.elem);
            Console.ReadKey();
        }

        private static void CreateCircleOfElem (int n, ref LinkElem<int> head)
        {
            LinkElem<int> now = head;
            now.elem = 1;
            int i;
            for (i=0; i < n - 1; i++)
            {
                now.next = new LinkElem<int>(i + 2);
                now = now.next;
            }
            now.next = head;
        }

        private static void CircleDelete(ref LinkElem<int> head)
        {
            LinkElem<int> now = head;
            ConsoleWriteList(now);
            while (now.elem != now.next.elem)
            {
                now.next = now.next.next;
                now = now.next;
                ConsoleWriteList(now);
            }
            head = now;
        }

        private static void ConsoleWriteList(LinkElem<int> head)
        {
            LinkElem<int> now = head;
            int start;
            int min = now.elem;
            do
            {
                now = now.next;
                if (now.elem < min) min = now.elem;
            }
            while (head.elem != now.elem);

            while (now.elem != min) now = now.next;

            start = now.elem;
            do
            {
                Console.Write(now.elem + " ");
                now = now.next;
            }
            while(start != now.elem);
            Console.WriteLine();
        }
    }
}
