using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Suppliers;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class OrderSectionDto<TItems>
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public AddressOutputDto Address { get; set; }
        public IEnumerable<TItems> Items { get; set; }
    }
}
