using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public interface IPricingService
    {
        OrderPrices CalculatePrices(Order order);

        OrderPrices CalculatePrices(CartOutputDto cart);
    }
}
