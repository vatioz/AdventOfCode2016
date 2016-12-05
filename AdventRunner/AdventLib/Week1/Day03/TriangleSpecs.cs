using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLib.Day03
{
    public class TriangleSpecs
    {
        public List<Triangle> Valid { get; }
        public List<Triangle> Invalid { get; }

        public TriangleSpecs()
        {
            Valid = new List<Triangle>();
            Invalid = new List<Triangle>();
        }

        public void AddVerticalTriangles(string[] threeLines)
        {
            if (threeLines.Length != 3)
                throw new NotSupportedException($"Only can parse vertical triangles from 3 lines (instead of {threeLines.Length})");

            int sideA1;
            int sideB1;
            int sideC1;
            GetSidesFromLine(threeLines[0], out sideA1, out sideB1, out sideC1);

            int sideA2;
            int sideB2;
            int sideC2;
            GetSidesFromLine(threeLines[1], out sideA2, out sideB2, out sideC2);

            int sideA3;
            int sideB3;
            int sideC3;
            GetSidesFromLine(threeLines[2], out sideA3, out sideB3, out sideC3);

            AddTriangle(sideA1, sideA2, sideA3);
            AddTriangle(sideB1, sideB2, sideB3);
            AddTriangle(sideC1, sideC2, sideC3);

        }

        public void AddTriangle(string line)
        {
            int sideA;
            int sideB;
            int sideC;
            GetSidesFromLine(line, out sideA, out sideB, out sideC);

            AddTriangle(sideA, sideB, sideC);
        }

        private static void GetSidesFromLine(string line, out int sideA, out int sideB, out int sideC)
        {
            var sides = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var a = sides[0].Trim();
            var b = sides[1].Trim();
            var c = sides[2].Trim();

            sideA = int.Parse(a);
            sideB = int.Parse(b);
            sideC = int.Parse(c);
        }

        private void AddTriangle(int sideA, int sideB, int sideC)
        {
            var t = new Triangle(sideA, sideB, sideC);
            if(t.IsValid())
                Valid.Add(t);
            else
                Invalid.Add(t);
        }

        public int InvalidCount => Invalid.Count;

        public int ValidCount => Valid.Count;
    }
}
