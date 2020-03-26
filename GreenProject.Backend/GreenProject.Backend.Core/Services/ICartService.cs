using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetails(int userId);

        Task<DeliveryInfoOutputDto> UpdateCartDeliveryInfo(int userId, DeliveryInfoInputDto deliveryInfo);

        Task InsertCartItem(int userId, CartItemInputDto item);

        Task UpdateCartItem(int userId, CartItemInputDto item);

        Task DeleteCartItem(int userId, int productId);

        Task<CustomerOrderDto> ConfirmCart(int userId);
    }
}
