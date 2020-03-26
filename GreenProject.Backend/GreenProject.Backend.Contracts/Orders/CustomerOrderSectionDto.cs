using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Orders.States;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Orders
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
