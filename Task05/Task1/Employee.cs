using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Employee : User
    {
        private string _post;
        private int _experience;

        public string post
        {
            get { return _post; }

            set { _post = value; }
        }

        public int experience
        {
            get { return _experience; }

            set
            {
                if (!string.IsNullOrWhiteSpace(_post)) _experience = value;
                else experience = 0;
            }
        }

        public Employee() : base()
        {
            this.post = "nopost";
            this.experience = 0;
        }

        public Employee(string firstname, string secondname, string patron) : base(firstname, secondname, patron)
        {

        }

        public Employee(string firstname, string secondname, string patron, string post, int exp) : base(firstname, secondname, patron)
        {
            this.post = post;
            this.experience = exp;
        }
    }
}
