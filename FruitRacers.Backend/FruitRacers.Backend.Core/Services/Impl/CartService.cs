using AutoMapper;
using FruitRacers.Backend.Contracts.Orders;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CartService : AbstractService, ICartService
    {
        public CartService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {

        }

        private IOrderRepository FilterCartForUser(int userId)
        {
            return this.Data
                .Orders
                .WithState(OrderState.Cart)
                .BelongingTo(userId);
        }

        public async Task<OrderDto> ConfirmCart()
        {
            Order cart = await this.FilterCartForUser(this.RequestingUser.UserId)
                .IncludingDetailsAndProducts()
                .FindOne()
                .Then(oc => oc
                    .Filter(c => c.Sections.SelectMany(s => s.Details).Count() > 0)
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

            CustomerType customerType = ServiceUtils.GetCustomerType(this.RequestingUser)
                .OrElseThrow(() => new UnauthorizedPurchaseException());

            cart.Sections
                .SelectMany(s => s.Details)
                .ForEach(d => this.AssignCurrentPriceToOrderDetail(d, customerType));

            await this.Data.SaveChanges();

            return this.Mapper.Map<OrderDto>(cart);
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

        public async Task DeleteCartItem(int productId)
        {
            Order cart = await this.FilterCartForUser(this.RequestingUser.UserId)
                .IncludingDetails()
                .FindOne()
                .Then(oc => oc.OrElseThrow(() => new CartItemNotFoundException(productId)));

            OrderDetail detail = cart.Sections
                .SelectMany(s => s.Details)
                .SingleOptional(d => d.ProductId == productId)
                .OrElseThrow(() => new CartItemNotFoundException(productId));

            OrderSection section = detail.OrderSection;
            section.Details.Remove(detail);

            if (section.Details.Count == 0)
            {
                cart.Sections.Remove(section);
            }

            await this.Data.SaveChanges();
        }

        public async Task<CartOutputDto> GetCartDetails()
        {
            return await this.FilterCartForUser(this.RequestingUser.UserId)
                .IncludingDetailsAndProducts()
                .FindOne()
                .Then(oc => oc
                    .Map(this.Mapper.Map<CartOutputDto>)
                    .OrElseGet(() => CartOutputDto.EmptyCart()));
        }

        public async Task InsertCartItem(CartItemInputDto item)
        {
            Product product = await this.Data
                .Products
                .FindOne(p => p.ProductId == item.ProductId)
                .Then(p => p.OrElseThrow(() => new ProductNotFoundException(item.ProductId)));

            Order cart = await this.FilterCartForUser(this.RequestingUser.UserId)
                .FindOne()
                .Then(oc => oc
                    .Map(Task.FromResult)
                    .OrElseGet(() => this.CreateCart(this.RequestingUser.UserId)));

            IOptional<OrderSection> optionalSection = cart.Sections
                .SingleOptional(s => s.SupplierId == product.SupplierId);

            // TODO: check if the number of sections exceeds a max value

            OrderSection section = optionalSection
                .OrElseGet(() => this.CreateCartSection(cart, product.SupplierId));

            section.Details.Add(new OrderDetail { ProductId = item.ProductId, OrderId = cart.OrderId });

            await this.Data.SaveChanges();
        }

        private OrderSection CreateCartSection(Order cart, int supplierId)
        {
            OrderSection section = new OrderSection { SupplierId = supplierId, State = OrderSectionState.Pending };
            cart.Sections.Add(section);
            return section;
        }

        private async Task<Order> CreateCart(int userId)
        {
            Order newCart = new Order
            {
                OrderState = OrderState.Cart,
                UserId = userId
            };
            await this.Data.Orders.Insert(newCart);
            return newCart;
        }

        public async Task<DeliveryInfoOutputDto> UpdateCartDeliveryInfo(DeliveryInfoInputDto deliveryInfo)
        {
            Order cart = await this.FilterCartForUser(this.RequestingUser.UserId)
                .FindOne()
                .Then(oc => this.CreateCart(this.RequestingUser.UserId));

            if (deliveryInfo.AddressId.HasValue)
            {
                Address address = await this.Data
                    .Addresses
                    .FindOne(a => a.AddressId == deliveryInfo.AddressId)
                    .Then(t => t.OrElseThrow(() => new AddressNotFoundException(deliveryInfo.AddressId.Value)));

                ServiceUtils.EnsureOwnership(address.UserId, this.RequestingUser.UserId);
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

        public async Task UpdateCartItem(CartItemInputDto cartItem)
        {
            Order order = await this.FilterCartForUser(this.RequestingUser.UserId)
                .IncludingDetails()
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
