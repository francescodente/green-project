namespace FruitRacers.Backend.Core.Dto
{
    public class OrderDetailDto
    {
        public SimpleProductDto<CategoryDto> Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}
