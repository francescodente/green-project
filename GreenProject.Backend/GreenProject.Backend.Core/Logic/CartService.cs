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
        private readonly IPricingService _pricing;
        private readonly IOrderScheduler _scheduler;
        private readonly OrdersSettings _settings;

        public CartService(IRequestSession request, IPricingService pricing, IOrderScheduler scheduler, OrdersSettings settings)
            : base(request)
        {
            _pricing = pricing;
            _scheduler = scheduler;
            _settings = settings;
        }

        private Task<User> RequireUserWithCart(int userId)
        {
            return RequireUserById(userId, q => q.IncludingCart());
        }

        private Task<User> RequireUserWithCartAndCustomerRoles(int userId)
        {
            return RequireUserById(userId, q => q.IncludingCart().IncludingCustomerRoles());
        }

        public async Task<OrderDto> ConfirmCart(int userId, DeliveryInfoDto.Input deliveryInfo)
        {
            User user = await RequireUserById(userId, q => q
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

            DateTime scheduleDate = await _scheduler
                .FindNextAvailableDate(DateTime.Today.AddDays(_settings.LockTimeSpanInDays), address.ZipCode);

            var order = new Order
            {
                Address = address,
                DeliveryDate = scheduleDate,
                IsSubscription = false,
                Notes = deliveryInfo.Notes,
                OrderState = OrderState.Pending,
                Timestamp = DateTime.Now
            };

            CustomerType customerType = user.GetCustomerType().Value;
            user.CartItems.Select(c => c.CreateOrderDetail()).ForEach(order.Details.Add);
            user.CartItems.Clear();

            _pricing.AssignPricesToOrder(order);
            user.Orders.Add(order);

            await Data.SaveChangesAsync();

            Notifications.OrderAccepted(order).FireAndForget();

            return Mapper.Map<OrderDto>(order);
        }

        public async Task<CartDto> GetCartDetails(int userId)
        {
            CartDto output = await Data
                .ActiveUsers()
                .Where(u => u.UserId == userId)
                .ProjectTo<CartDto>(Mapper.ConfigurationProvider)
                .SingleOptionalAsync()
                .Map(c => c.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            _pricing.AssignPricesToCart(output);

            return output;
        }

        public async Task InsertCartItem(int userId, QuantifiedProductDto.Input item)
        {
            Product product = await Data
                .VisibleProducts()
                .SingleOptionalAsync(p => p.ItemId == item.ProductId)
                .Map(op => op.OrElseThrow(() => NotFoundException.PurchasableItemWithId(item.ProductId)));

            User user = await RequireUserWithCartAndCustomerRoles(userId);

            user.AddProductToCart(product, item.Quantity);

            await Data.SaveChangesAsync();
        }

        public async Task UpdateCartItem(int userId, QuantifiedProductDto.Input item)
        {
            User user = await RequireUserWithCart(userId);

            user.UpdateCartItemQuantity(item.ProductId, item.Quantity);

            await Data.SaveChangesAsync();
        }

        public async Task DeleteCartItem(int userId, int productId)
        {
            User user = await RequireUserWithCart(userId);

            user.RemoveProductFromCart(productId);

            await Data.SaveChangesAsync();
        }

        public Task<int> GetCartSize(int userId)
        {
            return Data
                .ActiveUsers()
                .Where(u => u.UserId == userId)
                .Select(u => new { Size = u.CartItems.Count() })
                .SingleOptionalAsync()
                .Map(x => x.OrElseThrow(() => NotFoundException.UserWithId(userId)).Size);
        }
    }
}
