using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class SupplierImage
    {
        public int SupplierId { get; set; }
        public int ImageId { get; set; }
        public int Order { get; set; }

        public virtual Image Image { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
