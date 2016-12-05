using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Shared;

namespace AdventLib.Day04
{
    public class Day04:DayBase
    {
        public override object SolvePartOne()
        {
            var rlist = new RoomList();

            var lines = FileLineParser.GetAllLines(@"Day04\Day04Input.txt");
            foreach (var line in lines)
            {
                rlist.AddRoom(line);
                
            }

            return rlist.SumValidIds();
        }

        public override object SolvePartTwo()
        {
            var rlist = new RoomList();

            var lines = FileLineParser.GetAllLines(@"Day04\Day04Input.txt");
            foreach (var line in lines)
            {
                rlist.AddRoom(line);

            }

            var northpoleobjectstorage = rlist.SearchRoomByName("northpole");
            return $"{northpoleobjectstorage.ID} ({northpoleobjectstorage.DecipherName()})";
        }

        public override string PuzzleName => "Security Through Obscurity";
    }
}
