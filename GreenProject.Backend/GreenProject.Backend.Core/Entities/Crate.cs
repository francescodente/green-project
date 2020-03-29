using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Entities
{
    public class Crate : PurchasableItem
    {
        public Crate()
        {
            this.Compatibilities = new HashSet<CrateCompatibility>();
        }

        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public virtual ICollection<CrateCompatibility> Compatibilities { get; set; }
    }
}
