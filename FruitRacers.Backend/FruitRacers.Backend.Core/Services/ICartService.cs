using FruitRacers.Backend.Contracts.Orders;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetails();

        Task<DeliveryInfoOutputDto> UpdateCartDeliveryInfo(DeliveryInfoInputDto deliveryInfo);

        Task InsertCartItem(CartItemInputDto item);

        Task UpdateCartItem(CartItemInputDto item);

        Task DeleteCartItem(int productId);

        Task<OrderDto> ConfirmCart();
    }
}
