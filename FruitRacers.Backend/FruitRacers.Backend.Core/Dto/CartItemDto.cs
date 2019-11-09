namespace FruitRacers.Backend.Core.Dto
{
    public class CartItemDto
    {
        public ProductWithPricesDto<CategoryDto> Product { get; set; }
        public int Quantity { get; set; }
    }
}
