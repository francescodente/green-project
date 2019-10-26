using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class UserBusinessSupplier
    {
        public UserBusinessSupplier()
        {
            Images = new HashSet<Image>();
            Products = new HashSet<Product>();
        }

        public int UserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
