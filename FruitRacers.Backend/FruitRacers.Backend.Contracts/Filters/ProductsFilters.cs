using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Filters
{
    public class ProductsFilters
    {
        public IEnumerable<int> Categories { get; set; }
    }
}
