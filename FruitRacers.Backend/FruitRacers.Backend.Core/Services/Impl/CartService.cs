using AutoMapper;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {

        }

        private IOrderRepository FilterCartForUser(int userId)
        {
            return this.Session
                .Orders
                .WithState(OrderState.Cart)
                .BelongingTo(userId);
        }

        public async Task<int> ConfirmCartForUser(int userId)
        {
            Order cart = await this.FilterCartForUser(userId)
                .IncludingDetailsAndProducts()
                .FindOne()
                .Then(oc => oc
                    .Filter(c => c.OrderDetails.Count > 0)
                    .OrElseThrow(() => new CartEmptyException()));

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

            cart.OrderDetails.ForEach(d => this.AssignCurrentPriceToOrderDetail(d, CustomerType.Person)); // TODO: use correct role

            await this.Session.Orders.Update(cart);
            await this.Session.SaveChanges();

            return cart.OrderId;
        }

        private void AssignCurrentPriceToOrderDetail(OrderDetail detail, CustomerType customerType)
        {
            Price price = detail
                .Product
                .Prices
                .SingleOptional(p => p.Type == customerType)
                .OrElseThrow(() => new ReservedProductException(detail.ProductId, customerType));

            detail.Price = price.Value;
            detail.UnitName = price.UnitName;
            detail.UnitMultiplier = price.UnitMultiplier;
        }

        public async Task DeleteCartItemForUser(int userId, int productId)
        {
            int orderId = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => oc.Map(o => o.OrderId).OrElseThrow(() => new CartItemNotFoundException(productId)));

            OrderDetail cartItem = await this.Session
                .OrderDetails
                .FindOne(d => d.OrderId == orderId && d.ProductId == productId)
                .Then(od => od.OrElseThrow(() => new CartItemNotFoundException(productId)));

            await this.Session.OrderDetails.Delete(cartItem);
            await this.Session.SaveChanges();
        }

        public async Task<CartOutputDto> GetCartDetailsForUser(int userId)
        {
            return await this.FilterCartForUser(userId)
                .IncludingDetailsAndProducts()
                .FindOne()
                .Then(oc => oc
                    .Map(this.Mapper.Map<CartOutputDto>)
                    .OrElseGet(() => CartOutputDto.EmptyCart()));
        }

        public async Task InsertCartItemForUser(int userId, CartItemInputDto item)
        {
            Order cart = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => this.CreateCartIfAbsent(oc, userId));

            await this.Session.OrderDetails.Insert(new OrderDetail
            {
                OrderId = cart.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            });
            await this.Session.SaveChanges();
        }

        private async Task<Order> CreateCartIfAbsent(IOptional<Order> currentCart, int userId)
        {
            if (currentCart.IsAbsent())
            {
                Order newCart = new Order
                {
                    OrderState = (int)OrderState.Cart,
                    UserId = userId
                };
                await this.Session.Orders.Insert(newCart);
                return newCart;
            }
            return currentCart.Value;
        }

        public async Task UpdateCartDeliveryInfoForUser(int userId, DeliveryInfoInputDto deliveryInfo)
        {
            Order cart = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => this.CreateCartIfAbsent(oc, userId));

            if (deliveryInfo.AddressId.HasValue)
            {
                Address address = await this.Session
                    .Addresses
                    .FindOne(a => a.AddressId == deliveryInfo.AddressId)
                    .Then(t => t.OrElseThrow(() => new AddressNotFoundException(deliveryInfo.AddressId.Value)));

                ServiceUtils.EnsureOwnership(address.UserId, userId);
            }
            
            if (deliveryInfo.TimeSlotId.HasValue && deliveryInfo.DeliveryDate.HasValue)
            {
                await this.EnsureTimeSlotIsValid(deliveryInfo.TimeSlotId.Value, deliveryInfo.DeliveryDate.Value);
            }
            
            cart.TimeSlotId = deliveryInfo.TimeSlotId;
            cart.AddressId = deliveryInfo.AddressId;
            cart.Notes = deliveryInfo.Notes;
            cart.DeliveryDate = deliveryInfo.DeliveryDate;

            await this.Session.Orders.Update(cart);
            await this.Session.SaveChanges();
        }

        private async Task EnsureTimeSlotIsValid(int timeSlotId, DateTime date)
        {
            (TimeSlot timeSlot, int capacity) = await ServiceUtils.FindTimeSlotWithActualCapacity(this.Session, timeSlotId, date);

            if (timeSlot.Weekday != date.DayOfWeek)
            {
                throw new Exception(); // TODO: change to domain exception
            }
            if (capacity <= 0)
            {
                throw new TimeSlotFullException(timeSlot, date);
            }
        }

        public async Task UpdateCartItemForUser(int userId, CartItemInputDto cartItem)
        {
            int orderID = await this.FilterCartForUser(userId)
                .FindOne()
                .Then(oc => oc.Map(c => c.OrderId).OrElseThrow(() => new CartItemNotFoundException(cartItem.ProductId)));

            OrderDetail item = await this.Session
                .OrderDetails
                .FindOne(d => d.OrderId == orderID && d.ProductId == cartItem.ProductId)
                .Then(d => d.OrElseThrow(() => new CartItemNotFoundException(cartItem.ProductId)));

            item.Quantity = cartItem.Quantity;
            await this.Session.OrderDetails.Update(item);
            await this.Session.SaveChanges();
        }
    }
}
