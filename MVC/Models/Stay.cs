using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Stay
    {
        public Stay()
        {
            Undergoes = new HashSet<Undergoes>();
        }

        public int StayId { get; set; }
        public int Patient { get; set; }
        public int Room { get; set; }
        public DateTime StayStart { get; set; }
        public DateTime StayEnd { get; set; }

        public virtual Patient PatientNavigation { get; set; }
        public virtual Room RoomNavigation { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
