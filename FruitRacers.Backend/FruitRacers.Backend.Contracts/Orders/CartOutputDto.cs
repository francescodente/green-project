using System.Collections.Generic;
using System.Linq;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class CartOutputDto
    {
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<CartSectionDto> Sections { get; set; }
    }
}