using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Addresses
{
    public class AddressCollectionDto
    {
        public IEnumerable<AddressDto.Output> Addresses { get; set; }
        public int? DefaultAddressId { get; set; }
    }
}
