using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Products
{
    public abstract class AbstractProductDto<TCategory>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TCategory> Categories { get; set; }
        public IDictionary<CustomerTypeDto, PriceDto> Prices { get; set; }
    }
}
