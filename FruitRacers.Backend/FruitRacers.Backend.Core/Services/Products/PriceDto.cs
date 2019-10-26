namespace FruitRacers.Backend.Core.Services.Products
{
    public class PriceDto
    {
        public decimal Value { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
        public int Minimum { get; set; }
    }
}