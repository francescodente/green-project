using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Cart
{
    public class CartInsertionDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
