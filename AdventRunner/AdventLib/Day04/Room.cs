using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventLib.Day04
{
    public class Room
    {
        //public static Regex roomRE = new Regex(@"((\w+-)+)(?<id>\d+)\[(\w+)]");
        public static Regex roomRE = new Regex(@"((?<name>\w+)-)+(?<id>\d+)\[(?<hash>\w+)]");
        public int ID { get; }
        private string _hash;
        private List<string> _nameParts;

        public Room(string roomData)
        {
            var match = roomRE.Match(roomData);
            if (!match.Success)
                throw new NotSupportedException($"This is not recognized as valid room {roomData}.");

            var nameCaptures = match.Groups["name"].Captures;
            _nameParts = new List<string>();
            foreach (Capture nameCapture in nameCaptures)
            {
                _nameParts.Add(nameCapture.Value);
            }
            ID = int.Parse(match.Groups["id"].Value);

            _hash = match.Groups["hash"].Value;
        }

        public IEnumerable<Occurence> CountOccurences()
        {
            var occs = new Occurences();
            foreach (var namePart in _nameParts)
            {
                foreach (var ch in namePart)
                {
                    occs.Add(ch);
                }
            }

            return occs.GetTop5();
        }

        public bool IsRoomValid()
        {
            var top5 = CountOccurences();
            var result = new string(top5.Select(occ => occ.Letter).ToArray());
            return result == _hash;
        }

        public string DecipherName()
        {
            var sb = new StringBuilder();
            foreach (var namePart in _nameParts)
            {
                foreach (var c in namePart)
                {
                    sb.Append(Rotate(c, ID));
                }
                sb.Append(' ');
            }

            return sb.ToString(0, sb.Length - 1);
        }

        private char Rotate(char c, int times)
        {
            for (int i = 0; i < times; i++)
            {
                if (c == 'z')
                    c = 'a';
                else
                    c++;
            }

            return c;
        }
    }


    public class Occurences
    {
        public List<Occurence> AllOccurences { get; set; }

        public Occurences()
        {
            AllOccurences = new List<Occurence>();
        }

        public void Add(char c)
        {
            var found = AllOccurences.SingleOrDefault(o => o.Letter == c);
            if (found == null)
                AllOccurences.Add(new Occurence(c));
            else
                found.Increase();
        }

        public IEnumerable<Occurence> GetTop5()
        {
            AllOccurences.Sort(new OccurenceComparer());
            return AllOccurences.Take(5);
        }
    }

    public class Occurence
    {
        public Occurence(char c)
        {
            Letter = c;
            Count = 1;
        }

        public char Letter { get; set; }
        public int Count { get; set; }

        public void Increase()
        {
            Count++;
        }
    }

    public class OccurenceComparer : IComparer<Occurence>
    {
        public int Compare(Occurence x, Occurence y)
        {
            if (x.Count > y.Count)
                return -1;
            else if (x.Count < y.Count)
                return 1;
            else
            {
                return x.Letter.CompareTo(y.Letter);
            }
        }
    }
}
