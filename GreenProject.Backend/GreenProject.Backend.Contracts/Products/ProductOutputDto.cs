using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Products
{
    public class ProductOutputDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IDictionary<CustomerTypeDto, PriceDto> Prices { get; set; }
        public string ImageUrl { get; set; }
    }
}
