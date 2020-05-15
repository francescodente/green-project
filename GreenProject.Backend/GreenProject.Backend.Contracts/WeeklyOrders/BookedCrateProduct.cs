using GreenProject.Backend.Contracts.PurchasableItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.WeeklyOrders
{
    public class BookedCrateProduct
    {
        public ProductDto.Output Product { get; set; }
        public int Quantity { get; set; }
        public int? Maximum { get; set; }
    }
}
