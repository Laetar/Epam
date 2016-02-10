using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Round
    {
        private double _r;
        private Point _p = new Point();

        public double X
        {
            set { _p.x = value; }
            get { return _p.x; }
        }

        public double Y
        {
            set { _p.y = value; }
            get { return _p.y; }
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

        public bool IsNull()
        {
            if (Radius == 0) return true;
            else return false;
        }
    }
}
