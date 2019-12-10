using AutoMapper;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Shared.Utils;
using System;
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
            return await repository
                .CartOnly()
                .BelongingTo(userID)
                .FindOne()
                .Then(c => c.Value);
        }

        public async Task<int> ConfirmCartForUser(int userID)
        {
            Order cart = await this.RequireCart(userID);

            if (cart.DeliveryDate == null)
            {
                throw new MissingDeliveryInfoException();
            }
            if (cart.TimeSlotId == null)
            {
                throw new MissingDeliveryInfoException();
            }
            if (cart.AddressId == null)
            {
                throw new MissingDeliveryInfoException();
            }

            cart.OrderState = OrderState.Confirmed;
            cart.Timestamp = DateTime.Now;

            await this.Session.Orders.Update(cart);
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
            await this.Session.OrderDetails.Delete(detail);
            await this.Session.SaveChanges();
        }

        public async Task<CartOutputDto> GetCartDetailsForUser(int userID)
        {
            return await this.RequireCart(userID, true, true)
                .Then(this.Mapper.Map<Order, CartOutputDto>);
        }

        public async Task InsertCartItemForUser(int userID, CartItemInputDto item)
        {
            Order cart = await this.Session
                .Orders
                .CartOnly()
                .BelongingTo(userID)
                .FindOne()
                .Then(async c =>
                {
                    if (c.IsAbsent())
                    {
                        Order newCart = new Order
                        {
                            OrderState = (int)OrderState.Cart,
                            UserId = userID
                        };
                        await this.Session.Orders.Insert(newCart);
                        return newCart;
                    }
                    return c.Value;
                });

            await this.Session.OrderDetails.Insert(new OrderDetail
            {
                OrderId = cart.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
            await this.Session.SaveChanges();
        }

        public async Task UpdateCartDeliveryInfoForUser(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            Order cart = await this.RequireCart(userId);

            if (deliveryInfo.AddressId.HasValue)
            {
                Address address = await this.Session
                    .Addresses
                    .FindOne(a => a.AddressId == deliveryInfo.AddressId)
                    .ContinueWith(t => t.Result.Value);

                ServiceUtils.EnsureOwnership(address.UserId, userId);
            }
            
            if (deliveryInfo.TimeSlotId.HasValue && deliveryInfo.Date.HasValue)
            {
                int timeSlotCapacity = await this.Session
                    .TimeSlots
                    .GetActualCapacity(deliveryInfo.TimeSlotId.Value, deliveryInfo.Date.Value);
                if (timeSlotCapacity <= 0)
                {
                    throw new TimeSlotFullException();
                }
            }
            
            cart.TimeSlotId = deliveryInfo.TimeSlotId;
            cart.AddressId = deliveryInfo.AddressId;
            cart.Notes = deliveryInfo.Notes;
            cart.DeliveryDate = deliveryInfo.Date;

            await this.Session.Orders.Update(cart);
            await this.Session.SaveChanges();
        }

        public async Task UpdateCartItemForUser(int userId, CartItemInputDto cartItem)
        {
            int orderID = await this.RequireCart(userId)
                .Then(c => c.OrderId);
            OrderDetail item = await this.Session
                .OrderDetails
                .FindOne(d => d.OrderId == orderID && d.ProductId == cartItem.ProductId)
                .Then(d => d.Value);
            item.Quantity = cartItem.Quantity;
            await this.Session.OrderDetails.Update(item);
            await this.Session.SaveChanges();
        }
    }
}
