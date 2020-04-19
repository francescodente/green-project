using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetails(int userId);

        Task<int> GetCartSize(int userId);

        Task InsertCartItem(int userId, QuantifiedProductInputDto item);

        Task UpdateCartItem(int userId, QuantifiedProductInputDto item);

        Task DeleteCartItem(int userId, int productId);

        Task<OrderDto> ConfirmCart(int userId, DeliveryInfoInputDto deliveryInfo);
    }
}
