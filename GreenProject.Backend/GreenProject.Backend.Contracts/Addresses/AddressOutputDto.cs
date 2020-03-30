﻿namespace GreenProject.Backend.Contracts.Addresses
{
    public class AddressOutputDto
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
    }
}
