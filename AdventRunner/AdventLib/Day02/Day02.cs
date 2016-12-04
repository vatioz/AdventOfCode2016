using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventLib.Day02
{
    public class Day02 : DayBase
    {
        public override object SolvePartOne()
        {
            var lines = FileLineParser.GetAllLines(@"Day02\Day02Input.txt");
            return GetBathroomCode(lines);
        }

        public override object SolvePartTwo()
        {
            var lines = FileLineParser.GetAllLines(@"Day02\Day02Input.txt");
            return GetBathroomDesignCode(lines);
        }

        public override string PuzzleName => "Bathroom Security";


        public string GetBathroomCode(string input)
        {
            var lines = InputLineParser.GetAllLines(input);

            return GetBathroomCode(lines);
        }

        public string GetBathroomCode(IEnumerable<string> lines)
        {
            var pad = new KeyPad();
            pad.InitStandardKeyPad();
            foreach (var line in lines)
            {
                pad.ProcessSequence(line);
            }
            return pad.Sequence;
        }

        public string GetBathroomDesignCode(string input)
        {
            var lines = InputLineParser.GetAllLines(input);

            return GetBathroomDesignCode(lines);
        }

        public string GetBathroomDesignCode(IEnumerable<string> lines)
        {
            var pad = new KeyPad();
            pad.InitDesignKeyPad();
            foreach (var line in lines)
            {
                pad.ProcessSequence(line);
            }
            return pad.Sequence;
        }
    }
}
