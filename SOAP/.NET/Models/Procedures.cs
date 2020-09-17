using System;
using System.Collections.Generic;

namespace SOAP.Models
{
    public partial class Procedures
    {
        public Procedures()
        {
            TrainedIn = new HashSet<TrainedIn>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        public virtual ICollection<TrainedIn> TrainedIn { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
