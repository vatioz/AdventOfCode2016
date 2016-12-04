using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventLib.Day02;
using NUnit.Framework;

namespace AdventTests
{
    [TestFixture]

    public class Day02Tests
    {
        [TestCase("5", "UUUL", ExpectedResult = "1")]
        [TestCase("5", "ULL", ExpectedResult = "1")]
        [TestCase("1", "RRDDD", ExpectedResult = "9")]
        [TestCase("9", "LURDL", ExpectedResult = "8")]
        [TestCase("8", "UUUUD", ExpectedResult = "5")]
        public string ExampleLinePartI(string startingButton, string instructionLine)
        {
            var pad = new KeyPad();
            pad.InitStandardKeyPad();
            pad.SetStartingButton(startingButton);

            pad.ProcessSequence(instructionLine);
            return pad.Sequence;
        }


        [Test]
        public void ExamplePartI()
        {
            var day = new Day02();
            var sequence = day.GetBathroomCode(Input.Example);
            Assert.That(sequence, Is.EqualTo("1985"));

        }


        [TestCase("5", "UUUL", ExpectedResult = "5")]
        [TestCase("5", "ULL", ExpectedResult = "5")]
        [TestCase("5", "RRDDD", ExpectedResult = "D")]
        [TestCase("D", "LURDL", ExpectedResult = "B")]
        [TestCase("B", "UUUUD", ExpectedResult = "3")]
        public string ExampleLinePartII(string startingButton, string instructionLine)
        {
            var pad = new KeyPad();
            pad.InitDesignKeyPad();
            pad.SetStartingButton(startingButton);

            pad.ProcessSequence(instructionLine);
            return pad.Sequence;
        }

        [Test]
        public void ExamplePartII()
        {
            var day = new Day02();
            var sequence = day.GetBathroomDesignCode(Input.Example);
            Assert.That(sequence, Is.EqualTo("5DB3"));

        }
    }
}
