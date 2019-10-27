using FruitRacers.Backend.Core.Services.Categories;
using FruitRacers.Backend.Core.Services.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Cart
{
    public class CartItemDto
    {
        public ProductWithPricesDto<CategoryDto> Product { get; set; }
        public int Quantity { get; set; }
    }
}
