using GreenProject.Backend.Shared.Utils;
using System.Linq;

namespace GreenProject.Backend.Core.Entities.Extensions
{
    public static class PurchasableItemsExtensions
    {
        public static IOptional<Price> GetPrice(this PurchasableItem item, CustomerType type)
        {
            return item
                .Prices
                .SingleOptional(p => p.Type == type);
        }
    }
}
