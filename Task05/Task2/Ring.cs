using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Ring
    {
        public Round inRound;
        public Round outRound;

        public Ring()
        {
            inRound.X = 0;
            inRound.Y = 0;
            outRound.X = 0;
            outRound.Y = 0;
            inRound.Radius = 0;
            outRound.Radius = 0;
        }

        public Ring(double x, double y, double firstRoundRadius, double secondRoundRadius)
        {
            inRound.X = x;
            outRound.X = x;
            inRound.Y = y;
            outRound.Y = y;
            if (firstRoundRadius >= secondRoundRadius)
            {
                outRound.Radius = firstRoundRadius;
                inRound.Radius = secondRoundRadius;
            }
            else
            {
                outRound.Radius = secondRoundRadius;
                inRound.Radius = firstRoundRadius;
            }
        }

        public double Area ()
        {
            return (outRound.Area() - inRound.Area());
        }

        public double SumLength()
        {
            return (outRound.Length() + inRound.Length());
        }
    }
}
