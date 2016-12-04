using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventLib.Day01
{
    public class Day01 : DayBase
    {
        public override object SolvePartOne()
        {
            return HowFarIsHQ(Input.Directions);
        }

        public override object SolvePartTwo()
        {
            return HowFarIsFirstIntersection(Input.Directions);
        }

        public override string PuzzleName => "No Time for a Taxicab";

        public int HowFarIsHQ(string input)
        {
            var moves = input.Split(',');
            Grid grid = new Grid();
            foreach (var move in moves)
            {
                grid.Move(move);
            }
            return grid.ComputeDistance();
            
        }

        public int HowFarIsFirstIntersection(string input)
        {
            var moves = input.Split(',');
            Grid grid = new Grid();
            foreach (var move in moves)
            {
                grid.Move(move);
                if (grid.Duplicate != null)
                    break;
            }
            return grid.ComputeDistance(grid.Duplicate);

        }
    }
}
