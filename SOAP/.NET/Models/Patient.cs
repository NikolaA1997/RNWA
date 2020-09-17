using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Prescribes = new HashSet<Prescribes>();
            Stay = new HashSet<Stay>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int InsuranceId { get; set; }
        public int Pcp { get; set; }

        public virtual Physician PcpNavigation { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
        public virtual ICollection<Stay> Stay { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
