using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Addresses
{
    public static class AddressDto
    {
        public class Output
        {
            public int AddressId { get; set; }
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Name { get; set; }
            public string Telephone { get; set; }
            public string ZipCode { get; set; }
        }

        public class Input
        {
            public string Street { get; set; }
            public string HouseNumber { get; set; }
            public string Name { get; set; }
            public string Telephone { get; set; }
            public string ZipCode { get; set; }
        }
    }
}
