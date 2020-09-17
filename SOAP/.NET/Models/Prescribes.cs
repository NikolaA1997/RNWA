using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Prescribes
    {
        public int Physician { get; set; }
        public int Patient { get; set; }
        public int Medication { get; set; }
        public DateTime Date { get; set; }
        public int? Appointment { get; set; }
        public string Dose { get; set; }

        public virtual Appointment AppointmentNavigation { get; set; }
        public virtual Medication MedicationNavigation { get; set; }
        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
    }
}
