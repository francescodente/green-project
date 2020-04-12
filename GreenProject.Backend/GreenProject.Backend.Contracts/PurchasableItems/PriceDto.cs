using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class PriceDto
    {
        public decimal Value { get; set; }
        public UnitName UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}