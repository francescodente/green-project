using FruitRacers.Backend.Contracts.Categories;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Products
{
    public class ProductOutputDto : AbstractProductDto
    {
        public int ProductId { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
    }
}
