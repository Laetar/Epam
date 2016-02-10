using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Round
    {
        private double _r;
        private double _x;
        private double _y;

        public double X
        {
            set { _x = value; }
            get { return _x; }
        }

        public double Y
        {
            set { _y = value; }
            get { return _y; }
        }

        public double Radius
        {
            set
            {
                if (value < 0) _r = 0;
                else _r = value;   
            }
            get { return _r; }
        }

        public Round()
        {
            X = 0;
            Y = 0;
            Radius = 0;
        }

        public Round (double x, double y, double r)
        {
            X = x;
            Y = y;
            Radius = r;
        }

        public double Area()
        {
            return Math.PI * _r * _r;
        }

        public double Length ()
        {
            return 2 * Math.PI * _r;
        }
    }
}
