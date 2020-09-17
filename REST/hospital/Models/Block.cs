using System;
using System.Collections.Generic;

namespace hospital.Models
{
    public partial class Block
    {
        public Block()
        {
            OnCall = new HashSet<OnCall>();
            Room = new HashSet<Room>();
        }

        public int BlockFloor { get; set; }
        public int BlockCode { get; set; }

        public virtual ICollection<OnCall> OnCall { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
