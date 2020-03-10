using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils.Pricing;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CartService : AbstractService, ICartService
    {
        private readonly IPriceCalculator pricing;

        public CartService(IRequestSession request, IPriceCalculator pricing)
            : base(request)
        {
            this.pricing = pricing;
        }

        private DateTime DefaultDate => this.DateTime.Today.AddDays(1);

        private IOrderRepository FilterCartForUser(int userId)
        {
            return this.Data
                .Orders
                .WithState(OrderState.Cart)
                .BelongingTo(userId)
                .IncludingCustomerInfo();
        }

        private async Task<Order> CreateCart(User user)
        {
            Order newCart = new Order
            {
                OrderState = OrderState.Cart,
                UserId = user.UserId,
                AddressId = user.DefaultAddressId,
                DeliveryDate = this.DefaultDate
            };
            await this.Data.Orders.Insert(newCart);
            return newCart;
        }

        private CartOutputDto MapToCartDto(Order cart)
        {
            CartOutputDto cartOutput = this.Mapper.Map<CartOutputDto>(cart);
            Enumerable.Zip(cart.Sections, cartOutput.Sections).ForEach(s =>
            {
                s.Second.Prices = this.pricing.Calculate(s.First);
            });
            return cartOutput;
        }

        private async Task EnsureTimeSlotIsValid(int timeSlotId, DateTime date)
        {
            (TimeSlot timeSlot, int capacity) = await ServiceUtils.FindTimeSlotWithActualCapacity(this.Data, timeSlotId, date);

            if (timeSlot.Weekday != date.DayOfWeek)
            {
                throw new TimeSlotMismatchException(timeSlot, date);
            }
            if (capacity <= 0)
            {
                throw new TimeSlotFullException(timeSlot, date);
            }
        }

        public async Task<CustomerOrderDto> ConfirmCart(int userId)
        {
            Order cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .FindOne()
                .Then(oc => oc
                    .Filter(c => c.Sections.Any())
                    .OrElseThrow(() => new CartEmptyException()));

            if (cart.DeliveryDate == null || cart.AddressId == null || cart.TimeSlotId == null)
            {
                throw new MissingDeliveryInfoException();
            }

            cart.Confirm(this.DateTime.Now);

            await this.Data.SaveChanges();

            await Task.WhenAll(cart.Sections.Select(this.Notifications.OrderReceived));

            return this.Mapper.Map<CustomerOrderDto>(cart);
        }

        public async Task<DeliveryInfoOutputDto> UpdateCartDeliveryInfo(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());

            Order cart = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => oc
                    .Map(Task.FromResult)
                    .OrElseGet(() => this.CreateCart(user)));

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

            await this.Data.SaveChanges();
            return this.Mapper.Map<DeliveryInfoOutputDto>(cart);
        }

        public async Task<CartOutputDto> GetCartDetails(int userId)
        {
            IOptional<CartOutputDto> cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .FindOne()
                .Then(oc => oc.Map(this.MapToCartDto));

            if (cart.IsPresent())
            {
                return cart.Value;
            }
            else
            {
                User user = await this.RequireUserById(userId, r => r.IncludingAddresses());
                return new CartOutputDto
                {
                    DeliveryInfo = new DeliveryInfoOutputDto
                    {
                        Address = this.Mapper.Map<AddressOutputDto>(user.DefaultAddress),
                        DeliveryDate = this.DefaultDate
                    },
                    Sections = Enumerable.Empty<CartSectionDto>()
                };
            }
        }

        public async Task DeleteCartItem(int userId, int productId)
        {
            Order cart = await this.FilterCartForUser(userId)
                .IncludingSections()
                .FindOne()
                .Then(oc => oc.OrElseThrow(() => new CartItemNotFoundException(productId)));

            cart.RemoveOrderDetail(productId);

            await this.Data.SaveChanges();
        }

        public async Task InsertCartItem(int userId, CartItemInputDto item)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());

            Order cart = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => oc
                    .Map(Task.FromResult)
                    .OrElseGet(() => this.CreateCart(user)));

            Product product = await this.Data
                .Products
                .FindOne(p => p.ProductId == item.ProductId)
                .Then(p => p.OrElseThrow(() => new ProductNotFoundException(item.ProductId)));

            cart.AddProduct(product, item.Quantity);

            await this.Data.SaveChanges();
        }

        public async Task UpdateCartItem(int userId, CartItemInputDto cartItem)
        {
            Order order = await this.FilterCartForUser(userId)
                .IncludingSections()
                .FindOne()
                .Then(oc => oc.OrElseThrow(() => new CartItemNotFoundException(cartItem.ProductId)));

            OrderDetail item = order
                .Sections
                .SelectMany(s => s.Details)
                .SingleOptional(d => d.ProductId == cartItem.ProductId)
                .OrElseThrow(() => new CartItemNotFoundException(cartItem.ProductId));

            item.Quantity = cartItem.Quantity;

            await this.Data.SaveChanges();
        }
    }
}
