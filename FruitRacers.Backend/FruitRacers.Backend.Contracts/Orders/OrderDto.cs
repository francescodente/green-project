using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<SupplierOrderSectionDto<OrderDetailDto>> Details { get; set; }
    }
}
