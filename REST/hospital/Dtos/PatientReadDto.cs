using System;
using System.Collections.Generic;

namespace hospital.Models
{
    public partial class PatientReadDto
    {
        public int Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public int InsuranceId { get; set; }
        public string Phone { get; set; }
    }
}
