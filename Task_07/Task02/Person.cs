using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Person
    {
        private string _name = "noname";

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void Great(Person whatIs, int time)
        {
            if ((time < 12)&&(time >= 8))
            {
                Console.WriteLine("'Доброе утро {0}!', - сказал {1}", whatIs, _name);
            }
            else if (time < 17)
            {
                Console.WriteLine("'Добрый день {0}!', - сказал {1}", whatIs, _name);
            }
            else if (time >= 17)
            {
                Console.WriteLine("'Добрый вечер {0}!', - сказал {1}", whatIs, _name);
            }
        }

        public void Parting(Person whatIs)
        {
            Console.WriteLine("'Прощайте, мистер {0}!', - сказал {1}", whatIs, _name);
        }
    }
}
