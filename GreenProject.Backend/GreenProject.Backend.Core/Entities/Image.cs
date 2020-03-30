using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string Path { get; set; }

        public virtual PurchasableItem PurchasableItem { get; set; }
        public virtual Category Category { get; set; }
    }
}
