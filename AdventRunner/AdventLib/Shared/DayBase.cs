using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Shared
{
    [DebuggerDisplay("{PuzzleName,nq}")]
    public abstract class DayBase : IAdventDay
    {
        public abstract object SolvePartOne();
        public abstract object SolvePartTwo();
        public abstract string PuzzleName { get; }
    }
}
