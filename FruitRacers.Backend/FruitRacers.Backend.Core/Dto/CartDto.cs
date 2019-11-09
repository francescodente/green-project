using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Dto
{
    public class CartDto
    {
        public DeliveryInfoDto DeliveryInfo { get; set; }
        public IEnumerable<CartItemDto> Details { get; set; }
    }
}