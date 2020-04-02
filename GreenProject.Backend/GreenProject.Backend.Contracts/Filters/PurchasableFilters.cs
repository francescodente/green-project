using GreenProject.Backend.Contracts.PurchasableItems;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Filters
{
    public class PurchasableFilters
    {
        public IEnumerable<int> Categories { get; set; }

        public CustomerTypeDto CustomerType { get; set; }
    }
}
