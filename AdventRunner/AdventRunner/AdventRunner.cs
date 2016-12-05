using System;
using System.Collections.Generic;
using System.Diagnostics;
using AdventLib.Day01;
using AdventLib.Day02;
using AdventLib.Day03;
using AdventLib.Day04;
using AdventOfCode.Shared;

namespace AdventRunner
{
    [DebuggerDisplay("{Advent.Count}")]
    public class AdventRunner
    {
        [DebuggerStepThrough]
        public AdventRunner()
        {
            Advent = new List<IAdventDay>();
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public readonly List<IAdventDay> Advent;

        public void ComposeAllSolutions(bool filterSlowDays = true)
        {
            Advent.Add(new Day01());
            Advent.Add(new Day02());
            Advent.Add(new Day03());
            Advent.Add(new Day04());
        }

        public void ExecuteComposedSolutions()
        {
            var stopwatch = new Stopwatch();
            foreach (var adventDay in Advent)
            {
                Console.WriteLine();
                Console.WriteLine($"**** {adventDay.GetType().Name}: {adventDay.PuzzleName} ****");
                Console.WriteLine($"*");
                stopwatch.Restart();
                var resultPartOne = adventDay.SolvePartOne();
                stopwatch.Stop();
                Console.WriteLine($"*  part one) {resultPartOne} [{stopwatch.ElapsedMilliseconds} ms]");

                stopwatch.Restart();
                var resultPartTwo = adventDay.SolvePartTwo();
                stopwatch.Stop();
                Console.WriteLine($"*  part two) {resultPartTwo} [{stopwatch.ElapsedMilliseconds} ms]");
                Console.WriteLine($"*");
                Console.WriteLine($"************************");
                Console.WriteLine();
                Console.WriteLine();
            }
            stopwatch.Stop();
        }
    }
}