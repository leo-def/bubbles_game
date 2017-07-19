using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bubbles.Forms.Tools
{
    class PhysicsCalculator
    {
        public static double IncrementValue(double to_increment, double increment)
        {
            return (to_increment * (Math.Abs(to_increment) + Math.Abs(increment))) / Math.Abs(to_increment);
        }
        public static double DecrementValue(double to_increment, double increment)
        {
            return (to_increment * (Math.Abs(to_increment) - Math.Abs(increment))) / Math.Abs(to_increment);
        }
        public static bool InSequence(int value, int _sequenceStart, int _sequenceEnd)
        {
            if (value <= _sequenceStart && value >= _sequenceEnd)
            {
                return true;
            }
            return false;
        }
        

        public static int Compare(int p1, int p2)
        {
            if (p1 < p2) { return -1; }
            else if(p1 == p2){return 0;}
            return 1;
        }
    }
}
