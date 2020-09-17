using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class AffiliatedWith
    {
        public int Physician { get; set; }
        public int Department { get; set; }
        public byte PrimaryAffiliation { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
    }
}
