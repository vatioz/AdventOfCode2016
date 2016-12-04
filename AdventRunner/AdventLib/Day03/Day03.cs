using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventLib.Day03
{
    public class Day03 : DayBase
    {
        public override object SolvePartOne()
        {
            var specs = new TriangleSpecs();
            
            var lines = FileLineParser.GetAllLines("Day03\\Day03Input.txt");
            foreach (var line in lines)
            {
                specs.AddTriangle(line);
            }

            return specs.ValidCount;
        }

        public override object SolvePartTwo()
        {
            var specs = new TriangleSpecs();

            var lines = FileLineParser.GetAllLines("Day03\\Day03Input.txt").ToList();
            for (int i = 0; i < lines.Count; i+=3)
            {
                specs.AddVerticalTriangles(new [] {lines[i], lines[i+1] , lines[i+2] });
            }

            return specs.ValidCount;

        }

        public override string PuzzleName => "Squares With Three Sides";



    }
}
