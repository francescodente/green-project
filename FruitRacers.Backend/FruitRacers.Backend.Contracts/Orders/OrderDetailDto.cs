using FruitRacers.Backend.Contracts.Products;

namespace FruitRacers.Backend.Contracts.Orders
{
    public class OrderDetailDto
    {
        public ProductOutputDto Product { get; set; }
        public OrderDetailStateDto State { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}
