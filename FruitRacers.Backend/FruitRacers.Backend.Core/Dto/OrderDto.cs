using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DeliveryInfoDto DeliveryInfo { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
