using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Core.EntitiesExtensions;
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

        public async Task<OrderDto> ConfirmCart(int userId, DeliveryInfoDto.Input deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q
                .IncludingCart()
                .IncludingCustomerRoles()
                .Include(u => u.Addresses)
                    .ThenInclude(a => a.Zone));

            if (!user.CartItems.Any())
            {
                throw new CartEmptyException();
            }

            Address address = user
                .Addresses
                .SingleOptional(a => a.AddressId == deliveryInfo.AddressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(deliveryInfo.AddressId));

            DateTime scheduleDate = await this.scheduler
                .FindNextAvailableDate(this.DateTime.Today.AddDays(this.settings.LockTimeSpanInDays), address.ZipCode);
            
            Order order = new Order
            {
                Address = address,
                DeliveryDate = scheduleDate,
                IsSubscription = false,
                Notes = deliveryInfo.Notes,
                OrderState = OrderState.Pending,
                Timestamp = this.DateTime.Now
            };

            CustomerType customerType = user.GetCustomerType().Value;
            user.CartItems.Select(c => c.CreateOrderDetail(customerType)).ForEach(order.Details.Add);
            user.CartItems.Clear();

            this.pricing.AssignPricesToOrder(order);
            user.Orders.Add(order);

            await this.Data.SaveChangesAsync();

            await this.Notifications.OrderAccepted(order);

            return this.Mapper.Map<OrderDto>(order);
        }

        public async Task<CartDto> GetCartDetails(int userId)
        {
            CartDto output = await this.Data
                .ActiveUsers()
                .Where(u => u.UserId == userId)
                .ProjectTo<CartDto>(this.Mapper.ConfigurationProvider)
                .SingleOptionalAsync()
                .Map(c => c.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            this.pricing.AssignPricesToCart(output);

            return output;
        }

        public async Task InsertCartItem(int userId, QuantifiedProductDto.Input item)
        {
            Product product = await this.Data
                .VisibleProducts()
                .SingleOptionalAsync(p => p.ItemId == item.ProductId)
                .Map(op => op.OrElseThrow(() => NotFoundException.PurchasableItemWithId(item.ProductId)));

            User user = await this.RequireUserWithCartAndCustomerRoles(userId);

            user.AddProductToCart(product, item.Quantity);

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateCartItem(int userId, QuantifiedProductDto.Input item)
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
                .ActiveUsers()
                .Where(u => u.UserId == userId)
                .Select(u => new { Size = u.CartItems.Count() })
                .SingleOptionalAsync()
                .Map(x => x.OrElseThrow(() => NotFoundException.UserWithId(userId)).Size);
        }
    }
}
