using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class ProductInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceDto Price { get; set; }
        public int CategoryId { get; set; }
    }
}