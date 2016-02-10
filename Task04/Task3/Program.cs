using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            User u1 = new User();
            User u2 = new User();
            User u3 = new User();
            Console.WriteLine("Введите трех пользователей");
            Console.WriteLine("Первый пользователь:");
            ReadUser(ref u1);
            Console.WriteLine("Второй пользователь:");
            ReadUser(ref u2);
            Console.WriteLine("Третий пользователь:");
            ReadUser(ref u3);
            Console.WriteLine();
            WriteUser(u1);
            WriteUser(u2);
            WriteUser(u3);
            Console.ReadKey();
        }


        static private void ReadUser(ref User u)
        {
            string _readString;
            DateTime birthday;
            int age;

            Console.WriteLine("Имя:");
            _readString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_readString)) { u.firstname = "FirstNameIsNull"; Console.WriteLine("Вы ничего не ввели"); }
            else u.firstname = _readString;

            Console.WriteLine("Фамилия:");
            _readString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_readString)) { u.secondname = "SecondNameIsNull"; Console.WriteLine("Вы ничего не ввели"); }
            else u.secondname = _readString;

            Console.WriteLine("Отчество:");
            _readString = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_readString)) { u.patron = "PatronNameIsNull";  Console.WriteLine("Вы ничего не ввели"); }
            else u.patron = _readString;

            Console.WriteLine("Дата рождения в формате ГГГГ.ММ.ДД");
            if (DateTime.TryParse(Console.ReadLine(), out birthday)) u.birthday = birthday;
            else
            {
                Console.WriteLine("Вы неверно ввели дату рождения");
            }

            Console.WriteLine("Введите возраст");
            _readString = Console.ReadLine();
            if (int.TryParse(_readString, out age)) u.age = age;
            else
            {
                u.age = 0;
                Console.WriteLine("Введено неверне значение");
            }

            Console.WriteLine();
        }
        
        private static void WriteUser(User u)
        {
            DateTime a = new DateTime(0001, 01, 01);
            Console.WriteLine("Имя:{0}", u.firstname);
            Console.WriteLine("Фамилия:{0}", u.secondname);
            Console.WriteLine("Отчество:{0}", u.patron);
            if (u.birthday.Equals(a)) Console.WriteLine("Дата рождения не введена");
            else Console.WriteLine("Дата рождения: {0}", u.birthday.ToString("d"));
            Console.WriteLine("Возраст: {0}", u.age);
            Console.WriteLine();
        }   
    }
}
