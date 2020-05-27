using System.Collections.Generic;

namespace GreenProject.Backend.Entities
{
    public class Crate : PurchasableItem
    {
        public Crate()
        {
            Compatibilities = new HashSet<CrateCompatibility>();
            BookedCrates = new HashSet<BookedCrate>();
        }

        public int Capacity { get; set; }

        public virtual ICollection<CrateCompatibility> Compatibilities { get; set; }
        public virtual ICollection<BookedCrate> BookedCrates { get; set; }
    }
}
