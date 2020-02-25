using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class CustomerOrderDto : AbstractOrderDto
    {
        public IEnumerable<OrderSectionDto> Sections { get; set; }
    }
}
