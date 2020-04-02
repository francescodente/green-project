using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.PurchasableItems
{
    public class ProductInputDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<CustomerTypeDto, PriceDto> Prices { get; set; }
        public int CategoryId { get; set; }
    }
}