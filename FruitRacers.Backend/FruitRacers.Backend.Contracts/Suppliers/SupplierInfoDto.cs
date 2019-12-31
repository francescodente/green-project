﻿using FruitRacers.Backend.Contracts.Addresses;

namespace FruitRacers.Backend.Contracts.Suppliers
{
    public class SupplierInfoDto
    {
        public int SupplierId { get; set; }
        public AddressOutputDto Address { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoImageUrl { get; set; }
        public string BackgroundImageUrl { get; set; }
    }
}
