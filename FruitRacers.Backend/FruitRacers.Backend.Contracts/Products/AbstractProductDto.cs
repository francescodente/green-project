using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Products
{
    public abstract class AbstractProductDto<TCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TCategory> Categories { get; set; }
        public ProductPricesDto Prices { get; set; }
    }
}
