using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderDetailDto
    {
        public ProductOutputDto Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}
