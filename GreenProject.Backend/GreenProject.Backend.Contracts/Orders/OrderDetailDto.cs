using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.Contracts.Orders
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}
