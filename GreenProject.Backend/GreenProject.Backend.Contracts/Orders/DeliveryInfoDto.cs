using GreenProject.Backend.Contracts.Addresses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Orders
{
    public static class DeliveryInfoDto
    {
        public class Output
        {
            public string Notes { get; set; }
            public DateTime DeliveryDate { get; set; }
            public AddressDto.Output Address { get; set; }
        }

        public class Input
        {
            public string Notes { get; set; }
            public int AddressId { get; set; }
        }
    }
}
