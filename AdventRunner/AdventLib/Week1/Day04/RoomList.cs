using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventLib.Day04
{
    public class RoomList
    {
        List<Room> _rooms = new List<Room>();

        public void AddRoom(string line)
        {
            var room = new Room(line);
            _rooms.Add(room);
        }

        public IEnumerable<Room> ValidRooms { get { return _rooms.Where(r=>r.IsRoomValid()); } }

        public int SumValidIds()
        {
            return ValidRooms.Select(r => r.ID).Aggregate((a, b) => a + b);
        }

        public Room SearchRoomByName(string pattern)
        {
            foreach (var room in ValidRooms)
            {
                var name = room.DecipherName();
                if(name.Contains("storage"))
                    Debug.WriteLine(name);
                if(name.Contains(pattern))
                    return room;
            }

            return null;
        }
    }
}
