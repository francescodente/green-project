using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Services.Products
{
    public class ProductWithPricesDto<T> : ProductDto<T>
    {
        public ProductPricesDto Prices { get; set; }
    }
}