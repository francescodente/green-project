using System.Collections.Generic;
using System.Linq;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class CartOutputDto
    {
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<SupplierOrderSectionDto<CartItemOutputDto>> Sections { get; set; }

        public static CartOutputDto EmptyCart()
        {
            return new CartOutputDto
            {
                DeliveryInfo = new DeliveryInfoOutputDto(),
                Sections = Enumerable.Empty<SupplierOrderSectionDto<CartItemOutputDto>>()
            };
        }
    }
}