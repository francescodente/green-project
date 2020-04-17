using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.PurchasableItems;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class BookedCrateDto
    {
        public int OrderDetailId { get; set; }
        public CrateOutputDto CrateDescription { get; set; }
        public IEnumerable<QuantifiedProductOutputDto> Products { get; set; }
    }
}
