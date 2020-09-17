using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Medication
    {
        public Medication()
        {
            Prescribes = new HashSet<Prescribes>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Prescribes> Prescribes { get; set; }
    }
}
