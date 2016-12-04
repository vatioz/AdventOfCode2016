using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLib.Day03
{
    public class Triangle
    {
        public int SideA { get; }
        public int SideB { get; }
        public int SideC { get; }

        public Triangle(int sideA, int sideB, int sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public bool IsValid()
        {
            int ab = SideA + SideB;
            int ac = SideA + SideC;
            int bc = SideB + SideC;

            if (ab <= SideC || ac <= SideB || bc <= SideA)
                return false;

            return true;
        }
    }
}
