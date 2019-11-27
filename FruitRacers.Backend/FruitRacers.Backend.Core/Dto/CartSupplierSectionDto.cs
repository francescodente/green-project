using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Dto
{
    public class CartSupplierSectionDto
    {
        public SupplierDto Supplier { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; }
    }
}
