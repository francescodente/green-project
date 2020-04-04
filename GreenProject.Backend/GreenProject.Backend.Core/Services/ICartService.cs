using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetails(int userId);

        Task InsertCartItem(int userId, CartItemInputDto item);

        Task UpdateCartItem(int userId, CartItemInputDto item);

        Task DeleteCartItem(int userId, int productId);

        Task<CustomerOrderDto> ConfirmCart(int userId, DeliveryInfoInputDto deliveryInfo);
    }
}
