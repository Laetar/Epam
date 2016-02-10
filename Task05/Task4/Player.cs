using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Player : Character
    {
        public int HP { get; }
        public int str { get; }
        public int agi { get; }
        public int spd { get; }

        public Player () { }

        public void upStr() { }
        public void upAgi() { }
        public void upSpd() { }
    }
}
