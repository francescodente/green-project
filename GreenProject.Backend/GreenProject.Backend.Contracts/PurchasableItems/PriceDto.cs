namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class PriceDto
    {
        public decimal Value { get; set; }
        public UnitNameDto UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}