using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Cart;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
{
    public class CartService : AbstractService, ICartService
    {
        private readonly IPriceCalculator pricing;

        public CartService(IRequestSession request, IPriceCalculator pricing)
            : base(request)
        {
            this.pricing = pricing;
        }

        private DateTime FirstAvailableDate => this.DateTime.Today.AddDays(1);

        private IQueryable<Order> FilterCartForUser(int userId)
        {
            return this.Data
                .Orders
                .Where(o => o.OrderState == OrderState.Cart)
                .Where(o => o.UserId == userId)
                .IncludingDeliveryInfo()
                .Include(o => o.User)
                    .ThenInclude(u => u.CustomerBusiness)
                .Include(o => o.User)
                    .ThenInclude(u => u.Person);
        }

        private Order CreateCart(User user)
        {
            Order newCart = new Order
            {
                OrderState = OrderState.Cart,
                UserId = user.UserId,
                AddressId = user.DefaultAddressId,
                DeliveryDate = this.FirstAvailableDate,
            };
            this.Data.Orders.Add(newCart);
            return newCart;
        }

        private CartOutputDto MapToCartDto(Order cart)
        {
            CartOutputDto cartOutput = this.Mapper.Map<CartOutputDto>(cart);
            cart.Sections.Zip(cartOutput.Sections).ForEach(s =>
            {
                s.Second.Prices = this.pricing.Calculate(s.First);
            });
            return cartOutput;
        }

        private async Task EnsureTimeSlotIsValid(int timeSlotId, DateTime date)
        {
            if (date < this.FirstAvailableDate)
            {
                throw InvalidDeliveryInfoException.PastDate();
            }

            (TimeSlot timeSlot, int capacity) = await ServiceUtils.FindTimeSlotWithActualCapacity(this.Data, timeSlotId, date);

            if (timeSlot.Weekday != date.DayOfWeek)
            {
                throw InvalidDeliveryInfoException.WeekdayMismatch();
            }
            if (capacity <= 0)
            {
                throw InvalidDeliveryInfoException.TimeSlotFull();
            }
        }

        public async Task<CustomerOrderDto> ConfirmCart(int userId)
        {
            Order cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .SingleOptionalAsync()
                .Map(oc => oc
                    .Filter(c => c.Sections.Any())
                    .OrElseThrow(() => new CartEmptyException()));

            if (cart.TimeSlotId == null)
            {
                throw InvalidDeliveryInfoException.MissingTimeSlot();
            }

            cart.Confirm(this.DateTime.Now);

            await this.Data.SaveChangesAsync();

            await Task.WhenAll(cart.Sections.Select(this.Notifications.OrderReceived));

            return this.Mapper.Map<CustomerOrderDto>(cart);
        }

        public async Task<DeliveryInfoOutputDto> UpdateCartDeliveryInfo(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, q => q.Include(u => u.Addresses));

            Order cart = await this.FilterCartForUser(userId)
                .SingleOptionalAsync()
                .Map(oc => oc.OrElseGet(() => this.CreateCart(user)));

            if (deliveryInfo.AddressId.HasValue)
            {
                if (!user.Addresses.Any(a => a.AddressId == deliveryInfo.AddressId.Value))
                {
                    throw new UnauthorizedUserAccessException(userId);
                }
            }

            if (deliveryInfo.TimeSlotId.HasValue && deliveryInfo.DeliveryDate.HasValue)
            {
                await this.EnsureTimeSlotIsValid(deliveryInfo.TimeSlotId.Value, deliveryInfo.DeliveryDate.Value);
            }

            cart.TimeSlotId = deliveryInfo.TimeSlotId;
            cart.AddressId = deliveryInfo.AddressId;
            cart.Notes = deliveryInfo.Notes;
            cart.DeliveryDate = deliveryInfo.DeliveryDate;

            await this.Data.SaveChangesAsync();
            return this.Mapper.Map<DeliveryInfoOutputDto>(cart);
        }

        public async Task<CartOutputDto> GetCartDetails(int userId)
        {
            IOptional<CartOutputDto> cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .SingleOptionalAsync()
                .Map(oc => oc.Map(this.MapToCartDto));

            if (cart.IsPresent())
            {
                return cart.Value;
            }
            else
            {
                User user = await this.RequireUserById(userId, q => q.Include(u => u.Addresses));
                return new CartOutputDto
                {
                    DeliveryInfo = new DeliveryInfoOutputDto
                    {
                        Address = this.Mapper.Map<AddressOutputDto>(user.DefaultAddress),
                        DeliveryDate = this.FirstAvailableDate
                    },
                    Sections = Enumerable.Empty<CartSectionDto>()
                };
            }
        }

        public async Task DeleteCartItem(int userId, int productId)
        {
            Order cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .SingleOptionalAsync()
                .Map(oc => oc.OrElseThrow(() => NotFoundException.CartItem(productId)));

            cart.RemoveOrderDetail(productId);

            await this.Data.SaveChangesAsync();
        }

        public async Task InsertCartItem(int userId, CartItemInputDto item)
        {
            User user = await this.RequireUserById(userId, q => q.Include(u => u.Addresses));

            Order cart = await this.FilterCartForUser(userId)
                .SingleOptionalAsync()
                .Map(oc => oc.OrElseGet(() => this.CreateCart(user)));

            Product product = await this.Data
                .Products
                .SingleOptionalAsync(p => p.ProductId == item.ProductId)
                .Map(p => p.OrElseThrow(() => NotFoundException.ProductWithId(item.ProductId)));

            cart.AddProduct(product, item.Quantity);

            await this.Data.SaveChangesAsync();
        }

        public async Task UpdateCartItem(int userId, CartItemInputDto cartItem)
        {
            Order order = await this.FilterCartForUser(userId)
                .IncludingSections()
                .SingleOptionalAsync()
                .Map(oc => oc.OrElseThrow(() => NotFoundException.CartItem(cartItem.ProductId)));

            OrderDetail item = order
                .Sections
                .SelectMany(s => s.Details)
                .SingleOptional(d => d.ProductId == cartItem.ProductId)
                .OrElseThrow(() => NotFoundException.CartItem(cartItem.ProductId));

            item.Quantity = cartItem.Quantity;

            await this.Data.SaveChangesAsync();
        }
    }
}
