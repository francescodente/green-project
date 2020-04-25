using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities
{
    public class CrateCompatibility
    {
        public int ProductId { get; set; }
        public int CrateId { get; set; }
        public int? Maximum { get; set; }

        public virtual Crate Crate { get; set; }
        public virtual Product Product { get; set; }
    }
}
