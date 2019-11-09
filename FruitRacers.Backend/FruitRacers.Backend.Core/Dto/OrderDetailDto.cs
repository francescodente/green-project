using FruitRacers.Backend.Core.Services.Categories;
using FruitRacers.Backend.Core.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Suppliers
{
    public class OrderDetailDto
    {
        public ProductDto<CategoryDto> Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}
