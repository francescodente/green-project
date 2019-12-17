using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class CartEmptyException : DomainException
    {
        public CartEmptyException()
            : base("Unable to confirm the order because the shopping cart is empty")
        {

        }
    }
}
