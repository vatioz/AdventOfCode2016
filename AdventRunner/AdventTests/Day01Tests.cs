using AdventLib.Day01;
using NUnit.Framework;

namespace AdventTests
{
    [TestFixture]
    public class Day01Tests
    {
        #region | Part I
        [Test]
        public void GridInit()
        {
            Grid grid = new Grid();

            var distance = grid.ComputeDistance();

            Assert.That(distance, Is.EqualTo(0));
        }

        [TestCase("R1", ExpectedResult = 1)]
        [TestCase("L1", ExpectedResult = 1)]
        [TestCase("R2", ExpectedResult = 2)]
        [TestCase("L2", ExpectedResult = 2)]
        [TestCase("R3", ExpectedResult = 3)]
        [TestCase("L3", ExpectedResult = 3)]
        [TestCase("R4", ExpectedResult = 4)]
        [TestCase("L4", ExpectedResult = 4)]

        [TestCase("L1 ", ExpectedResult = 1)]
        [TestCase(" R1", ExpectedResult = 1)]
        public int GridSingleMove(string movement)
        {
            Grid grid = new Grid();
            grid.Move(movement);
            var distance = grid.ComputeDistance();

            return distance;
        }

        [TestCase("R1, R1, R1, R1", ExpectedResult = 0)]
        [TestCase("R1, R1, R1, R1, R1, R1, R1, R1", ExpectedResult = 0)]
        [TestCase("R1, R1, R1, R1, R1, R1, R1, R1, R1, R1, R1", ExpectedResult = 1)]

        [TestCase("L1, L1, L1, L1", ExpectedResult = 0)]
        [TestCase("L1, L1, L1, L1, L1, L1, L1, L1", ExpectedResult = 0)]
        [TestCase("L1, L1, L1, L1, L1, L1, L1, L1, L1, L1, L1", ExpectedResult = 1)]

        [TestCase("R5, L5", ExpectedResult = 10)]
        [TestCase("R5, R5", ExpectedResult = 10)]
        [TestCase("L5, R5", ExpectedResult = 10)]
        [TestCase("L5, L5", ExpectedResult = 10)]

        [TestCase("L50, L50", ExpectedResult = 100)]
        [TestCase("L555, L555", ExpectedResult = 1110)]
        public int ComposedMove(string movement)
        {
            Day01 day = new Day01();
            return day.HowFarIsHQ(movement);
        }


        [Test]
        public void Example1()
        {
            var input = "R2, L3";
            Day01 day = new Day01();
            int distance = day.HowFarIsHQ(input);
            Assert.That(distance, Is.EqualTo(5));
        }

        [Test]
        public void Example2()
        {
            var input = "R2, R2, R2";
            Day01 day = new Day01();
            int distance = day.HowFarIsHQ(input);
            Assert.That(distance, Is.EqualTo(2));
        }

        [Test]
        public void Example3()
        {
            var input = "R5, L5, R5, R3";
            Day01 day = new Day01();
            int distance = day.HowFarIsHQ(input);
            Assert.That(distance, Is.EqualTo(12));
        }

        #endregion

        #region | Part II

        [Test]
        public void IntersectExample()
        {
            Day01 day = new Day01();
            var distance = day.HowFarIsFirstIntersection("R8, R4, R4, R8");
            Assert.That(distance, Is.EqualTo(4));
        }

        #endregion
    }
}
