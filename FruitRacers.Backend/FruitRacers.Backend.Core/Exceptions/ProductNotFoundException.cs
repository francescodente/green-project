using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class ProductNotFoundException : DomainException
    {
        public ProductNotFoundException(int productId)
            : base(string.Format("Unable to find product with id {0}", productId))
        {

        }
    }
}
