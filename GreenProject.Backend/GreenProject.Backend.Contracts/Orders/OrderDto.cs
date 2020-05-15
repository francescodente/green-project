using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public bool IsSubscription { get; set; }
        public DateTime Timestamp { get; set; }
        public OrderState OrderState { get; set; }
        public DeliveryInfoDto.Output DeliveryInfo { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
