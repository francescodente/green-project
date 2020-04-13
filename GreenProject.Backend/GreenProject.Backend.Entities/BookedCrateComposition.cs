using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public class BookedCrateComposition
    {
        public int ProductId { get; set; }
        public int BookedCrateId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual BookedCrate BookedCrate { get; set; }
    }
}
