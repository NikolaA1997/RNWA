using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Nurse
    {
        public Nurse()
        {
            Appointment = new HashSet<Appointment>();
            OnCall = new HashSet<OnCall>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public byte Registered { get; set; }
        public int Ssn { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<OnCall> OnCall { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
