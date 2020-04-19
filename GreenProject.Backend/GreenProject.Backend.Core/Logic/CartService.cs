using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class CartService : AbstractService, ICartService
    {
        private readonly IPricingService pricing;
        private readonly IOrderScheduler scheduler;
        private readonly OrdersSettings settings;

        public CartService(IRequestSession request, IPricingService pricing, IOrderScheduler scheduler, OrdersSettings settings)
            : base(request)
        {
            this.pricing = pricing;
            this.scheduler = scheduler;
            this.settings = settings;
        }

        private Task<User> RequireUserWithCart(int userId)
        {
            return this.RequireUserById(userId, q => q.IncludingCart());
        }

        private Task<User> RequireUserWithCartAndCustomerRoles(int userId)
        {
            return this.RequireUserById(userId, q => q.IncludingCart().IncludingCustomerRoles());
        }

        public async Task<OrderDto> ConfirmCart(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .IncludingCart()
                .IncludingCustomerRoles());

            if (!user.CartItems.Any())
            {
                throw new CartEmptyException();
            }

            string zipCode = await this.Data
                .Addresses
                .Where(a => a.AddressId == deliveryInfo.AddressId)
                .Where(a => a.UserId == userId)
                .Select(a => a.ZipCode)
                .SingleOptionalAsync()
                .Map(z => z.OrElseThrow(() => NotFoundException.AddressWithId(deliveryInfo.AddressId)));
            DateTime scheduleDate = await this.scheduler
                .FindNextAvailableDate(this.DateTime.Today.AddDays(this.settings.LockTimeSpanInDays), zipCode);
            
            Order order = new Order
            {
                AddressId = deliveryInfo.AddressId,
                DeliveryDate = scheduleDate,
                IsSubscription = false,
                Notes = deliveryInfo.Notes,
                OrderState = OrderState.Pending,
                Timestamp = this.DateTime.Now
            };

            CustomerType customerType = user.GetCustomerType().Value;
            user.CartItems.Select(c => c.CreateOrderDetail(customerType)).ForEach(order.Details.Add);
            this.pricing.AssignPricesToOrder(order);
            user.CartItems.Clear();

            user.Orders.Add(order);

            await this.Data.SaveChangesAsync();

            await this.Notifications.OrderReceived(order);

            return this.Mapper.Map<OrderDto>(order);
        }

        public async Task<CartOutputDto> GetCartDetails(int userId)
        {
            CartOutputDto output = await this.Data
                .Users
                .Where(u => u.UserId == userId)
                .ProjectTo<CartOutputDto>(this.Mapper.ConfigurationProvider)
                .SingleOptionalAsync()
                .Map(c => c.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            this.pricing.AssignPricesToCart(output);

            return output;
        }

        public async Task InsertCartItem(int userId, QuantifiedProductInputDto item)
        {
            Product product = await this.Data
                .Products
                .SingleOptionalAsync(p => p.ItemId == item.ProductId)
                .Map(op => op.OrElseThrow(() => NotFoundException.PurchasableItemWithId(item.ProductId)));

            User user = await this.RequireUserWithCartAndCustomerRoles(userId);

            user.AddProductToCart(product, item.Quantity);

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateCartItem(int userId, QuantifiedProductInputDto item)
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

        public Task<int> GetCartSize(int userId)
        {
            return this.Data
                .Users
                .Where(u => u.UserId == userId)
                .Select(u => new { Size = u.CartItems.Count() })
                .SingleOptionalAsync()
                .Map(x => x.OrElseThrow(() => NotFoundException.UserWithId(userId)).Size);
        }
    }
}
