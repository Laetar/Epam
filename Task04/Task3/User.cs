using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class User
    {
        private int _age;
        public string firstname { get; set; }
        public string secondname { get; set; }
        public string patron { get; set; }
        public DateTime birthday = new DateTime(0001,01,01);
        public int age
        {
            get { return _age; }
            set
            {
                if (value < 0) age = 0;
                else _age = value;
            }
        }

        public User()
        {
            firstname = "noname";
            secondname = "noname";
            patron = "noname";
            birthday = new DateTime();
            age = 0;
        }

        public User(string firstname, string secondname, string patron)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.patron = patron;
        }

        public User(string firstname, string secondname, string patron, DateTime birthday, int age)
        {
            this.firstname = firstname;
            this.secondname = secondname;
            this.patron = patron;
            this.birthday = birthday;
            this.age = age;
        }
    }
}
