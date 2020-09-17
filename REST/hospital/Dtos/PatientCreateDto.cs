using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hospital.Models
{
    public partial class PatientCreateDto
    {
        [Required]
        public int Ssn { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        //[Required]
        //public int InsuranceId { get; set; }
        [Required]
        public int Pcp { get; set; }
    }
}
