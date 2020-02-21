using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class SupplierOrderDto : AbstractOrderDto
    {
        public OrderSectionDto Details { get; set; }
    }
}
