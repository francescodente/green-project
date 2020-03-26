using GreenProject.Backend.Contracts.Orders.States;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Orders
{
    public class CustomerOrderDto
    {
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public OrderStateDto OrderState { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<CustomerOrderSectionDto> Sections { get; set; }
    }
}
