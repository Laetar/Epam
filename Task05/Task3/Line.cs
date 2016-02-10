using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Line
    {
        private Point _p1 = new Point();
        private Point _p2 = new Point();

        public double x1
        {
            set { _p1.x = value; }
            get { return _p1.x; }
        }

        public double y1
        {
            set { _p1.y = value; }
            get { return _p1.y; }
        }

        public double x2
        {
            set { _p2.x = value; }
            get { return _p2.x; }
        }

        public double y2
        {
            set { _p2.y = value; }
            get { return _p2.y; }
        }

        public Line()
        {
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
        }

        public Line(double x1, double y1,double x2, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public virtual double Length()
        {
            return Math.Sqrt((x1- x2)* (x1 - x2) + (y1 - y2)* (y1 - y2));
        }

        public bool IsNull()
        {
            if (x1 + x2 + y1 + y2 == 0) return true;
            else return false;
        }
    }
}
