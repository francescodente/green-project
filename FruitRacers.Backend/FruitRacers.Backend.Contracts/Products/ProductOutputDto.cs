using FruitRacers.Backend.Contracts.Categories;

namespace FruitRacers.Backend.Contracts.Products
{
    public class ProductOutputDto : AbstractProductDto<CategoryDto>
    {
        public int ProductId { get; set; }
    }
}
