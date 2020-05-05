using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public static class CompatibilityDto
    {
        public class Output
        {
            public ProductDto.Output Product { get; set; }
            public int? Maximum { get; set; }
        }

        public class Input
        {
            public int CrateId { get; set; }
            public int? Maximum { get; set; }
        }
    }
}
