﻿using FruitRacers.Backend.Contracts.Orders;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetails();

        Task UpdateCartDeliveryInfo(DeliveryInfoInputDto deliveryInfo);

        Task InsertCartItem(CartItemInputDto item);

        Task UpdateCartItem(CartItemInputDto item);

        Task DeleteCartItem(int productId);

        Task<int> ConfirmCart();
    }
}
