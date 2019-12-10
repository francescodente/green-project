using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class Image
    {
        public Image()
        {
            Categories = new HashSet<Category>();
            ProductImages = new HashSet<ProductImage>();
            SupplierImages = new HashSet<SupplierImage>();
        }

        public int ImageId { get; set; }
        public string Path { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<SupplierImage> SupplierImages { get; set; }
    }
}
