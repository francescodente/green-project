using FruitRacers.Backend.Contracts.Suppliers;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class SupplierOrderSectionDto<TItems>
    {
        public SupplierInfoDto Supplier { get; set; }
        public IEnumerable<TItems> Items { get; set; }
    }
}
