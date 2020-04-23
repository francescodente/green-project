using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class ProductOutputDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PriceDto Price { get; set; }
        public decimal IvaPercentage { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
