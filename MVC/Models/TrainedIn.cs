using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class TrainedIn
    {
        public int Physician { get; set; }
        public int Treatment { get; set; }
        public DateTime CertificationDate { get; set; }
        public DateTime CertificationExpires { get; set; }

        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Procedures TreatmentNavigation { get; set; }
    }
}
