using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public static class QuantifiedProductDto
    {
        public class Input
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class Output
        {
            public ProductDto.Output Product { get; set; }
            public int Quantity { get; set; }
        }
    }
}
