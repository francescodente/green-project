using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class BookedCrateProduct
    {
        public ProductDto.Output Product { get; set; }
        public int Quantity { get; set; }
        public int? Maximum { get; set; }
    }
}
