using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Product : PurchasableItem
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            BookedCrateProducts = new HashSet<BookedCrateProduct>();
            Compatibilities = new HashSet<CrateCompatibility>();
        }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<BookedCrateProduct> BookedCrateProducts { get; set; }
        public virtual ICollection<CrateCompatibility> Compatibilities { get; set; }
    }
}
