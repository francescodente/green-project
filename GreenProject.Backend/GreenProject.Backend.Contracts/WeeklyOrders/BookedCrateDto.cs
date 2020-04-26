using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.PurchasableItems;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class BookedCrateDto
    {
        public int OrderDetailId { get; set; }
        public CrateDto.Output CrateDescription { get; set; }
        public IEnumerable<QuantifiedProductDto.Output> Products { get; set; }
    }
}
