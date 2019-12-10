using FruitRacers.Backend.Contracts.Users.Roles;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class SupplierOrderSectionDto<TItems>
    {
        public SupplierDto Supplier { get; set; }
        public IEnumerable<TItems> Items { get; set; }
    }
}
