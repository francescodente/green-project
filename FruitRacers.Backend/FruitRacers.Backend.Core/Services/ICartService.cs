﻿using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartDetailsForUser(int userID);

        Task UpdateCartDeliveryInfoForUser(int userID, DeliveryInfoDto deliveryInfo);

        Task InsertCartItemForUser(int userID, CartInsertionDto insertion);

        Task UpdateCartItemForUser(int userID, CartInsertionDto insertion);

        Task DeleteCartItemForUser(int userID, int productID);

        Task<int> ConfirmCartForUser(int userID);
    }
}