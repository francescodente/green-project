using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Orders.States;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class CustomerOrderSectionDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public AddressOutputDto SupplierAddress { get; set; }
        public IEnumerable<OrderDetailDto> Items { get; set; }
        public OrderSectionStateDto State { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
