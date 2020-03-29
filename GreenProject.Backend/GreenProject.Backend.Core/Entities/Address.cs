using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Entities
{
    public class Address
    {
        public Address()
        {
            Orders = new HashSet<Order>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ZipCode ZipCodeData { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
