using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Filters
{
    public class ProductsFilters
    {
        public IEnumerable<int> Categories { get; set; }
    }
}
