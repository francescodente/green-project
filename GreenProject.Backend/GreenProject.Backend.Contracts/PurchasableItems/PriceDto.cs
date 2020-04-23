using GreenProject.Backend.Entities;
using GreenProject.Backend.Entities.Utils;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class PriceDto
    {
        public Money Value { get; set; }
        public UnitName UnitName { get; set; }
        public decimal UnitMultiplier { get; set; }
    }
}