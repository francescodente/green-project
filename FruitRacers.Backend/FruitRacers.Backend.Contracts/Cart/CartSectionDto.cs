using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Contracts.Suppliers;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Cart
{
    public class CartSectionDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public IEnumerable<CartItemOutputDto> Items { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}
