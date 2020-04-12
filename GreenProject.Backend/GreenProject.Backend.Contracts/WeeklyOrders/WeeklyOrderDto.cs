﻿using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class WeeklyOrderDto
    {
        public bool IsSubscribed { get; set; }
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<BookedCrateDto> Crates { get; set; }
        public IEnumerable<CartItemOutputDto> ExtraProducts { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}