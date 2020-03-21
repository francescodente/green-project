using FruitRacers.Backend.Contracts.Orders;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Cart
{
    public class CartOutputDto
    {
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<CartSectionDto> Sections { get; set; }
    }
}