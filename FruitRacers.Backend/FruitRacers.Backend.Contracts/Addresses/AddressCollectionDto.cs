using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Contracts.Addresses
{
    public class AddressCollectionDto
    {
        public IEnumerable<AddressOutputDto> Addresses { get; set; }
        public int? DefaultAddressId { get; set; }
    }
}
