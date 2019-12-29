﻿using FruitRacers.Backend.Contracts.Addresses;

namespace FruitRacers.Backend.Contracts.Users.Roles
{
    public class SupplierDto : BusinessDto
    {
        public string Description { get; set; }
        public AddressOutputDto Address { get; set; }
    }
}
