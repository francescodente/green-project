using FruitRacers.Backend.Contracts.Categories;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Products
{
    public class ProductOutputDto : AbstractProductDto
    {
        public int ProductId { get; set; }
        public CategoryDto Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
