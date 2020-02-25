using FruitRacers.Backend.Shared.Utils;
using System.Linq;

namespace FruitRacers.Backend.Core.Entities.Extensions
{
    public static class ProductsExtensions
    {
        public static IOptional<Price> GetPrice(this Product product, CustomerType type)
        {
            return product
                .Prices
                .SingleOptional(p => p.Type == type);
        }
    }
}
