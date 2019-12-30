using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Products
{
    public abstract class AbstractProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<CustomerTypeDto, PriceDto> Prices { get; set; }
    }
}
