using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Cart
{
    public class CartDto
    {
        public IEnumerable<QuantifiedProductDto.Output> CartItems { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}