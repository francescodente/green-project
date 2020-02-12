using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<OrderSectionDto<OrderDetailDto>> Sections { get; set; }
    }
}
