using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class CartItemNotFoundException : DomainException
    {
        public CartItemNotFoundException(int productId)
            : base(string.Format("Unable to find products in the cart with id {0}", productId))
        {
            
        }
    }
}
