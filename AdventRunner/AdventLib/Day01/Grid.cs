using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventLib.Day01
{
    public class Location
    {
        public Location()
        {
        }

        public Location(string location)
        {
            var coordinates = location.Split(',');
            X = int.Parse(coordinates[0]);
            Y = int.Parse(coordinates[1]);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override bool Equals(object obj)
        {
            var loc = (Location) obj;
            return this.X == loc.X && this.Y == loc.Y;
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    [DebuggerDisplay("{CurrentLocation.X}, {CurrentLocation.Y}")]
    public class Grid
    {
        public Location Duplicate { get; set; }
        private List<string> _history;

        public Grid()
        {
            CurrentLocation = new Location();
            CurrentDirection = Direction.North;
            _history = new List<string>();
        }

        public Location CurrentLocation { get; set; }
        public Direction CurrentDirection { get; set; }

        public void Move(string input)
        {
            var sanitizedInput = input.Trim();
            var turn = sanitizedInput[0];
            var walk = int.Parse(sanitizedInput.Substring(1));

            ChangeDirection(turn);

            switch (CurrentDirection)
            {
                case Direction.East:
                    //AddToHistory(walk, 0);
                    //CurrentLocation.X += walk;
                    Move(() => { CurrentLocation.X += 1; }, Math.Abs(walk));
                    break;
                case Direction.West:
                    //CurrentLocation.X -= walk;
                    Move(() => { CurrentLocation.X -= 1; }, Math.Abs(walk));
                    break;
                case Direction.North:
                    //CurrentLocation.Y += walk;
                    Move(() => { CurrentLocation.Y += 1; }, Math.Abs(walk));
                    break;
                case Direction.South:
                    //CurrentLocation.Y -= walk;
                    Move(() => { CurrentLocation.Y -= 1; }, Math.Abs(walk));
                    break;
            }

            var duplicates = _history.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key);
            var duplicate = duplicates.FirstOrDefault();
            if(duplicate != null)
                Duplicate = new Location(duplicate);
        }

        


        private void Move(Action oneStepAction, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                oneStepAction();
                _history.Add(CurrentLocation.ToString());
            }
        }

        private void ChangeDirection(char turn)
        {
            if (turn == 'R')
                TurnRight();

            if (turn == 'L')
                TurnLeft();
        }

        private void TurnLeft()
        {
            if(CurrentDirection == Direction.North)
                CurrentDirection = Direction.West;
            else
                CurrentDirection -= 1;
        }

        private void TurnRight()
        {
            if (CurrentDirection == Direction.West)
                CurrentDirection = Direction.North;
            else
                CurrentDirection += 1;
        }

        public int ComputeDistance(Location location)
        {
            return Math.Abs(location.X) + Math.Abs(location.Y);
        }

        public int ComputeDistance()
        {
            return ComputeDistance(CurrentLocation);
        }
    }
}
