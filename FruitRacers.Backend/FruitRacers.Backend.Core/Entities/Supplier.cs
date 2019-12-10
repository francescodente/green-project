using FruitRacers.Backend.Core.Entities.Abstractions;
using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Supplier : AbstractBusiness
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            SupplierImages = new HashSet<SupplierImage>();
        }

        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SupplierImage> SupplierImages { get; set; }
    }
}
