using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class CartService : AbstractService, ICartService
    {
        private readonly IPriceCalculator pricing;
        private readonly IOrderScheduler scheduler;

        public CartService(IRequestSession request, IPriceCalculator pricing, IOrderScheduler scheduler)
            : base(request)
        {
            this.pricing = pricing;
            this.scheduler = scheduler;
        }

        private Task<User> RequireUserWithCart(int userId)
        {
            return this.RequireUserById(userId, q => q.IncludingCart());
        }

        private Task<User> RequireUserWithCartAndCustomerRoles(int userId)
        {
            return this.RequireUserById(userId, q => q.IncludingCart().IncludingCustomerRoles());
        }

        public async Task<CustomerOrderDto> ConfirmCart(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .IncludingCart()
                .IncludingCustomerRoles()
                .Include(u => u.Addresses));

            if (!user.CartItems.Any())
            {
                throw new CartEmptyException();
            }

            Address address = user.Addresses
                .SingleOptional(a => a.AddressId == deliveryInfo.AddressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(deliveryInfo.AddressId));
            
            DateTime scheduleDate = await this.scheduler.FindNextAvailableDateForAddress(this.Data, address, this.DateTime.Today.AddDays(1));

            CustomerType customerType = user.GetCustomerType().Value;
            
            Order order = new Order
            {
                Address = address,
                DeliveryDate = scheduleDate,
                IsSubscription = false,
                Notes = deliveryInfo.Notes,
                OrderState = OrderState.Pending,
                Timestamp = this.DateTime.Now
            };

            user.CartItems.Select(c => c.CreateOrderDetail(customerType)).ForEach(order.Details.Add);
            this.pricing.UpdateOrderPrices(order);
            user.CartItems.Clear();

            user.Orders.Add(order);

            await this.Data.SaveChangesAsync();

            await this.Notifications.OrderReceived(order);

            return this.Mapper.Map<CustomerOrderDto>(order);
        }

        public async Task<CartOutputDto> GetCartDetails(int userId)
        {
            User user = await this.RequireUserWithCartAndCustomerRoles(userId);
            CustomerType customerType = user.GetCustomerType().Value;
            return new CartOutputDto
            {
                Items = this.Mapper.Map<IEnumerable<CartItemOutputDto>>(user.CartItems),
                Prices = this.pricing.Calculate(user.CartItems, customerType)
            };
        }

        public async Task InsertCartItem(int userId, CartItemInputDto item)
        {
            Product product = await this.Data
                .Products
                .SingleOptionalAsync(p => p.ItemId == item.ProductId)
                .Map(op => op.OrElseThrow(() => NotFoundException.PurchasableItemWithId(item.ProductId)));

            User user = await this.RequireUserWithCartAndCustomerRoles(userId);

            user.AddProductToCart(product, item.Quantity);

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateCartItem(int userId, CartItemInputDto item)
        {
            User user = await this.RequireUserWithCart(userId);

            user.UpdateCartItemQuantity(item.ProductId, item.Quantity);

            await this.Data.SaveChangesAsync();
        }

        public async Task DeleteCartItem(int userId, int productId)
        {
            User user = await this.RequireUserWithCart(userId);

            user.RemoveProductFromCart(productId);

            await this.Data.SaveChangesAsync();
        }
    }
}
