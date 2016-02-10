using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public double a
        {
            set
            {
                if (value < 0) _a = 0;
                else _a = value;
            }
            get { return _a; }
        }

        public double b
        {
            set
            {
                if (value < 0) _b = 0;
                else _b = value;
            }
            get { return _b; }
        }

        public double c
        {
            set
            {
                if (value < 0) _c = 0;
                else _c = value;
            }
            get { return _c; }
        }

        public Triangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }

        public Triangle(double x, double y, double z)
        {
            a = x;
            b = y;
            c = z;
        }

        public double Area ()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - b));
        }

        public double Perimeter()
        {
            return a + b + c;
        }
    }
}
