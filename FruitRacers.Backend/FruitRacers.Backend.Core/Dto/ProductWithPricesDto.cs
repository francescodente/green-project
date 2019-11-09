namespace FruitRacers.Backend.Core.Dto
{
    public class ProductWithPricesDto<T> : ProductDto<T>
    {
        public ProductPricesDto Prices { get; set; }
    }
}