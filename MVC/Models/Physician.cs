using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Physician
    {
        public Physician()
        {
            AffiliatedWith = new HashSet<AffiliatedWith>();
            Appointment = new HashSet<Appointment>();
            Department = new HashSet<Department>();
            Patient = new HashSet<Patient>();
            Prescribes = new HashSet<Prescribes>();
            TrainedIn = new HashSet<TrainedIn>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Ssn { get; set; }

        public virtual ICollection<AffiliatedWith> AffiliatedWith { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
        public virtual ICollection<TrainedIn> TrainedIn { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
