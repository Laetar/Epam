using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    abstract class Let
    {
        public int x;
        public int y;
        public int size;
    }

    class Tree : Let
    {
        public Tree() { }
    }

    class Rock : Let
    {
        public Rock() { }
    }
}
