using FruitRacers.Backend.Contracts.Orders.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Orders
{
    public abstract class AbstractOrderDto
    {
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public OrderStateDto OrderState { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
    }
}
