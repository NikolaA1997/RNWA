using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Room
    {
        public Room()
        {
            Stay = new HashSet<Stay>();
        }

        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public int BlockFloor { get; set; }
        public int BlockCode { get; set; }
        public byte Unavailable { get; set; }

        public virtual Block Block { get; set; }
        public virtual ICollection<Stay> Stay { get; set; }
    }
}
