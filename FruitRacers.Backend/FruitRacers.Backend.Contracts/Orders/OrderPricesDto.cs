using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class OrderPricesDto
    {
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }
}
