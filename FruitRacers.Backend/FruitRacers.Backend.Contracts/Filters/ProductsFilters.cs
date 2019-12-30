using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Filters
{
    public class ProductsFilters
    {
        public int? SupplierId { get; set; }
        public IEnumerable<int> Categories { get; set; }
    }
}
