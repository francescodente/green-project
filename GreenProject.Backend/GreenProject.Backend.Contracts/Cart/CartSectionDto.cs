using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Suppliers;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Cart
{
    public class CartSectionDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public IEnumerable<CartItemOutputDto> Items { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
