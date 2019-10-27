using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class Image
    {
        public Image()
        {
            Categories = new HashSet<Category>();
        }

        public int ImageId { get; set; }
        public string Path { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual UserBusinessSupplier Supplier { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
