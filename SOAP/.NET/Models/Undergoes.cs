using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Undergoes
    {
        public int Patient { get; set; }
        public int Procedures { get; set; }
        public int Stay { get; set; }
        public DateTime DateUndergoes { get; set; }
        public int Physician { get; set; }
        public int? AssistingNurse { get; set; }

        public virtual Nurse AssistingNurseNavigation { get; set; }
        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Procedures ProceduresNavigation { get; set; }
        public virtual Stay StayNavigation { get; set; }
    }
}
