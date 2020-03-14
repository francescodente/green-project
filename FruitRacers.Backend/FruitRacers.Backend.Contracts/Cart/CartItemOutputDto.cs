using FruitRacers.Backend.Contracts.Categories;
using FruitRacers.Backend.Contracts.Products;

namespace FruitRacers.Backend.Contracts.Cart
{
    public class CartItemOutputDto
    {
        public ProductOutputDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
