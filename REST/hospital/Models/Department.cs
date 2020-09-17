using System;
using System.Collections.Generic;

namespace hospital.Models
{
    public partial class Department
    {
        public Department()
        {
            AffiliatedWith = new HashSet<AffiliatedWith>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int Head { get; set; }

        public virtual Physician HeadNavigation { get; set; }
        public virtual ICollection<AffiliatedWith> AffiliatedWith { get; set; }
    }
}
