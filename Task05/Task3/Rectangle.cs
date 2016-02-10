using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Rectangle : Line
    {
        public Rectangle() : base()
        {

        }

        public Rectangle (double x1, double y1, double x2, double y2) : base(x1,y1,x2,y2)
        {

        }
        public override double Length()
        {
            return 2 * (Math.Abs(x1 - x2) + Math.Abs(y1 - y2));
        }

        public double Area ()
        {
            return Math.Abs((x1 - x2) * (y1 - y2));
        }
    }
}
