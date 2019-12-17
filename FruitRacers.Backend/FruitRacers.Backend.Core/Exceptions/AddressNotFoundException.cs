using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class AddressNotFoundException : DomainException
    {
        public AddressNotFoundException(int addressId)
            : base(string.Format("Unable to find address with id {0}", addressId))
        {

        }
    }
}
