using FruitRacers.Backend.Core.Services.Cart;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Suppliers
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public DeliveryInfoDto DeliveryInfo { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<OrderDetailDto> Details { get; set; }
    }
}
