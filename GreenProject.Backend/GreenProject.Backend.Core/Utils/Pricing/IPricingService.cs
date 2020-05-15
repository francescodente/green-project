using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Entities.Utils;

namespace GreenProject.Backend.Core.Utils.Pricing
{
    public interface IPricingService
    {
        OrderPrices CalculatePrices(Order order);

        OrderPrices CalculatePrices(CartDto cart);
    }
}
