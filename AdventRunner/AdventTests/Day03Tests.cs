using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventLib.Day03;
using NUnit.Framework;

namespace AdventTests
{
    [TestFixture]
    public class Day03Tests
    {
        [TestCase(5, 10, 25, ExpectedResult = false)]
        [TestCase(25, 10, 5, ExpectedResult = false)]
        [TestCase(5, 25, 10, ExpectedResult = false)]
        [TestCase(11, 14, 25, ExpectedResult = false)]
        [TestCase(11, 25, 14, ExpectedResult = false)]
        [TestCase(25, 14, 11, ExpectedResult = false)]
        [TestCase(25, 14, 15, ExpectedResult = true)]
        [TestCase(15, 14, 25, ExpectedResult = true)]
        [TestCase(14, 25, 15, ExpectedResult = true)]
        public bool Example1(int sideA, int sideB, int sideC)
        {
            var tri = new Triangle(sideA, sideB, sideC);
            return tri.IsValid();

        }

        [Test]
        public void Example2()
        {
            var specs = new TriangleSpecs();
            specs.AddVerticalTriangles(new [] {"101 301 501", "102 302 502", "103 303 503"});
            specs.AddVerticalTriangles(new [] {"201 401 601", "202 402 602", "203 403 603"});

            Assert.That(specs.ValidCount, Is.EqualTo(6));

            Assert.That(specs.Valid.All(t=> t.SideA-1 == t.SideB-2 && t.SideB-2 == t.SideC-3));
        }
    }
}
