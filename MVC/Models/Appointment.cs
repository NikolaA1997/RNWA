using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Prescribes = new HashSet<Prescribes>();
        }

        public int AppointmentId { get; set; }
        public int Patient { get; set; }
        public int? PrepNurse { get; set; }
        public int Physician { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ExaminationRoom { get; set; }

        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Nurse PrepNurseNavigation { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
    }
}
