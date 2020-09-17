using System;
using System.Collections.Generic;

namespace hospital.Models
{
    public partial class AppointmentReadDto
    {
        public AppointmentReadDto()
        {
            Prescribes = new HashSet<PrescribeReadDto>();
        }

        public int AppointmentId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string ExaminationRoom { get; set; }
                                                                                                                                                                                        
        public virtual PatientReadDto PatientNavigation { get; set; }
        public virtual ICollection<PrescribeReadDto> Prescribes { get; set; }
    }
}
