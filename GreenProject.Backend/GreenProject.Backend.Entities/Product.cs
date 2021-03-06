using System.Collections.Generic;

namespace GreenProject.Backend.Entities
{
    public class Product : PurchasableItem
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            SubProducts = new HashSet<OrderDetailSubProduct>();
            Compatibilities = new HashSet<CrateCompatibility>();
            Compositions = new HashSet<BookedCrateComposition>();
        }

        public UnitName UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
        public int CrateMultiplier { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderDetailSubProduct> SubProducts { get; set; }
        public virtual ICollection<CrateCompatibility> Compatibilities { get; set; }
        public virtual ICollection<BookedCrateComposition> Compositions { get; set; }
    }
}
