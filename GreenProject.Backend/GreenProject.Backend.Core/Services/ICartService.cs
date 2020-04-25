using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.Orders.Delivery;
using GreenProject.Backend.Contracts.PurchasableItems;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartDetails(int userId);

        Task<int> GetCartSize(int userId);

        Task InsertCartItem(int userId, QuantifiedProductDto.Input item);

        Task UpdateCartItem(int userId, QuantifiedProductDto.Input item);

        Task DeleteCartItem(int userId, int productId);

        Task<OrderDto> ConfirmCart(int userId, DeliveryInfoDto.Input deliveryInfo);
    }
}
