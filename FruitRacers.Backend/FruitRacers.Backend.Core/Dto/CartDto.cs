using FruitRacers.Backend.Core.Services.Addresses;
using FruitRacers.Backend.Core.Services.TimeSlots;
using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Services.Cart
{
    public class CartDto
    {
        public DeliveryInfoDto DeliveryInfo { get; set; }
        public IEnumerable<CartItemDto> Details { get; set; }
    }
}