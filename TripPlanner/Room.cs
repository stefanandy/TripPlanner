using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Room
    {
        public int RoomNumber { get; set; }
        public int MaxOccupants { get; set; }
        public bool DisabledFriendly { get; set; }
        public bool HasBalcony { get; set; }
        public bool InUse { get; set; }
        public bool HasAirconditioned { get; set; }
        public string Surface { get; set; }

        public Room() { }

        public Room(string line) {
            var values = line.Split(',');


            RoomNumber = Int32.Parse(values[0]);
            MaxOccupants = Int32.Parse(values[1]);
            DisabledFriendly = Convert.ToBoolean(values[2]);
            HasBalcony = Convert.ToBoolean(values[3]);
            InUse = Convert.ToBoolean(values[4]);
            HasAirconditioned = Convert.ToBoolean(values[5]);
            Surface = values[6];
            
        }

        
    }
}
