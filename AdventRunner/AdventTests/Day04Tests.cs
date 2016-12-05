using AdventLib.Day04;
using NUnit.Framework;
using System.Linq;

namespace AdventTests
{
    [TestFixture]
    public class Day04Tests
    {
        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", ExpectedResult = true)]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", ExpectedResult = true)]
        [TestCase("not-a-real-room-404[oarel]", ExpectedResult = true)]
        [TestCase("totally-real-room-200[decoy]", ExpectedResult = false)]
        public bool Examples(string roomData)
        {
            var room = new Room(roomData);
            return room.IsRoomValid();
        }

        [TestCase("aaaaa-bbb-z-y-x-123[abxyz]", ExpectedResult = "abxyz")]
        [TestCase("a-b-c-d-e-f-g-h-987[abcde]", ExpectedResult = "abcde")]
        [TestCase("not-a-real-room-404[oarel]", ExpectedResult = "oarel")]
        [TestCase("totally-real-room-200[decoy]", ExpectedResult = "loart")]
        public string ExamplesCounting(string roomData)
        {
            var room = new Room(roomData);
            var top5 = room.CountOccurences();
            var result = new string(top5.Select(occ => occ.Letter).ToArray());
            return result;
        }

        [Test]
        public void ExampleDecipher()
        {
            var room = new Room("qzmt-zixmtkozy-ivhz-343[aaaaa]");
            var name = room.DecipherName();
            Assert.That(name, Is.EqualTo("very encrypted name"));
        }
    }
}
