using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {

        }

        private async Task<Order> RequireCart(int userID, bool includeDetails = false, bool includeProducts = false)
        {
            IOrderRepository repository = this.Session.Orders;
            if (includeDetails)
            {
                repository = includeProducts ? repository.IncludingDetailsAndProducts() : repository.IncludingDetails();
            }
            return await repository.CartOnly().BelongingTo(userID).FindOne().Then(c => c.Value);
        }

        public async Task<int> ConfirmCartForUser(int userID)
        {
            Order cart = await this.RequireCart(userID);

            cart.OrderState = (int) OrderState.Confirmed;

            this.Session.Orders.Update(cart);
            await this.Session.SaveChanges();

            return cart.OrderId;
        }

        public async Task DeleteCartItemForUser(int userID, int productID)
        {
            int orderID = await this.RequireCart(userID, true).Then(c => c.OrderId);
            OrderDetail detail = await this.Session
                .OrderDetails
                .FindOne(d => d.ProductId == productID && d.OrderId == orderID)
                .Then(d => d.Value);
            this.Session.OrderDetails.Delete(detail);
            await this.Session.SaveChanges();
        }

        public async Task<CartDto> GetCartDetailsForUser(int userID)
        {
            return await this.RequireCart(userID, true, true)
                .Then(this.Mapper.Map<Order, CartDto>);
        }

        public async Task InsertCartItemForUser(int userID, CartInsertionDto insertion)
        {
            Order cart = (await this.Session.Orders.CartOnly().BelongingTo(userID).GetAll()).SingleOrDefault();
            if (cart == null)
            {
                cart = new Order
                {
                    OrderState = (int)OrderState.Cart,
                    UserId = userID
                };
                this.Session.Orders.Insert(cart);
            }
            this.Session.OrderDetails.Insert(new OrderDetail
            {
                OrderId = cart.OrderId,
                ProductId = insertion.ProductId,
                Quantity = insertion.Quantity
            });
            await this.Session.SaveChanges();
        }

        public async Task UpdateCartDeliveryInfoForUser(int userID, DeliveryInfoDto deliveryInfo)
        {
            Order cart = await this.RequireCart(userID);

            if (deliveryInfo.Address != null)
            {
                Address address = await this.Session
                    .Addresses
                    .FindOne(a => a.AddressId == deliveryInfo.Address.AddressId)
                    .ContinueWith(t => t.Result.Value);

                ServiceUtils.EnsureOwnership(address.UserId, userID);
            }
            
            if (deliveryInfo.TimeSlot != null && deliveryInfo.Date != null)
            {
                int timeSlotCapacity = await this.Session.TimeSlots.GetActualCapacity(deliveryInfo.TimeSlot.TimeSlotId, deliveryInfo.Date.Value);
                if (timeSlotCapacity <= 0)
                {
                    throw new TimeSlotFullException();
                }
            }
            
            cart.TimeSlotId = deliveryInfo.TimeSlot?.TimeSlotId;
            cart.AddressId = deliveryInfo.Address?.AddressId;
            cart.Notes = deliveryInfo.Notes;
            cart.DeliveryDate = deliveryInfo.Date;

            this.Session.Orders.Update(cart);
            await this.Session.SaveChanges();
        }

        public async Task UpdateCartItemForUser(int userID, CartInsertionDto cartItem)
        {
            int orderID = await this.RequireCart(userID)
                .Then(c => c.OrderId);
            OrderDetail item = await this.Session
                .OrderDetails
                .FindOne(d => d.OrderId == orderID && d.ProductId == cartItem.ProductId)
                .Then(d => d.Value);
            item.Quantity = cartItem.Quantity;
            this.Session.OrderDetails.Update(item);
            await this.Session.SaveChanges();
        }
    }
}
