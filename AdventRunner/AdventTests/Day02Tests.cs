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
        [TestCase("UUUL", ExpectedResult = "1")]
        public string ExampleLine1(string instructionLine)
        {
            var pad = new KeyPad();
            pad.Init();

            pad.ProcessSequence(instructionLine);
            return pad.Sequence;
        }
    }
}
