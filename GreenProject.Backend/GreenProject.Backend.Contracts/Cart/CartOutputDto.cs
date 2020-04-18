using GreenProject.Backend.Contracts.Orders;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Cart
{
    public class CartOutputDto
    {
        public IEnumerable<QuantifiedProductOutputDto> Items { get; set; }
        public OrderPricesDto Prices { get; set; }
    }
}