using GreenProject.Backend.Contracts.Orders.States;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Orders
{
    public class SupplierOrderDto
    {
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public OrderStateDto OrderState { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<OrderDetailDto> Items { get; set; }
        public OrderSectionStateDto SectionState { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
