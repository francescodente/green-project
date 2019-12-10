using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class CartOutputDto
    {
        public DeliveryInfoOutputDto DeliveryInfo { get; set; }
        public IEnumerable<SupplierOrderSectionDto<CartItemOutputDto>> Details { get; set; }
    }
}