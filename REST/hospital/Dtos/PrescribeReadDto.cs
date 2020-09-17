using System;
using System.Collections.Generic;

namespace hospital.Models
{
    public partial class PrescribeReadDto
    {
        public int Medication { get; set; }
        public DateTime Date { get; set; }
        public string Dose { get; set; }
    }
}
