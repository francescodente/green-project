using GreenProject.Backend.Entities;
using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public static class ProductDto
    {
        public class Output
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public Money Price { get; set; }
            public UnitName UnitName { get; set; }
            public decimal UnitMultiplier { get; set; }
            public decimal IvaPercentage { get; set; }
            public string ImageUrl { get; set; }
            public bool IsStarred { get; set; }
            public int CategoryId { get; set; }
        }

        public class Insertion
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Money Price { get; set; }
            public UnitName UnitName { get; set; }
            public decimal UnitMultiplier { get; set; }
            public decimal IvaPercentage { get; set; }
            public bool IsStarred { get; set; }
            public int CategoryId { get; set; }
            public IEnumerable<CompatibilityDto.Input> CompatibleCrates { get; set; }
        }

        public class Update
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Money Price { get; set; }
            public decimal IvaPercentage { get; set; }
            public bool IsStarred { get; set; }
            public int CategoryId { get; set; }
            public IEnumerable<CompatibilityDto.Input> CompatibleCrates { get; set; }
        }
    }
}
