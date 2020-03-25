using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Linq;

namespace FruitRacers.Backend.Core.Entities.Extensions
{
    public static class OrdersExtensions
    {
        public static void Confirm(this Order order, DateTime timestamp)
        {
            CustomerType customerType = order.User
                .GetCustomerType()
                .OrElseThrow(() => new UnauthorizedPurchaseException());

            order.MaterializePrices(customerType);

            order.OrderState = OrderState.Pending;
            order.Timestamp = timestamp;
        }

        private static void MaterializePrices(this Order order, CustomerType customerType)
        {
            order.Sections
                .SelectMany(s => s.Details)
                .ForEach(d => d.AssignCurrentProductPrice(customerType));
        }

        private static void AssignCurrentProductPrice(this OrderDetail detail, CustomerType customerType)
        {
            Price price = detail
                .Product
                .GetPrice(customerType)
                .OrElseThrow(() => new ReservedProductException(detail.ProductId, customerType));

            detail.Price = price.Value;
            detail.UnitName = price.UnitName;
            detail.UnitMultiplier = price.UnitMultiplier;
        }

        public static OrderSection CreateOrderSection(this Order order, int supplierId)
        {
            OrderSection section = new OrderSection
            {
                SupplierId = supplierId,
                State = OrderSectionState.Pending
            };
            order.Sections.Add(section);
            return section;
        }

        public static void RemoveOrderDetail(this Order order, int productId)
        {
            OrderDetail detail = order.Sections
                .SelectMany(s => s.Details)
                .SingleOptional(d => d.ProductId == productId)
                .OrElseThrow(() => NotFoundException.CartItem(productId));

            OrderSection section = detail.OrderSection;
            section.Details.Remove(detail);

            if (section.Details.Count == 0)
            {
                order.Sections.Remove(section);
            }
        }

        public static void AddProduct(this Order order, Product product, int quantity)
        {
            IOptional<OrderSection> optionalSection = order.Sections
                .SingleOptional(s => s.SupplierId == product.SupplierId);

            // TODO: check if the number of sections exceeds a max value

            OrderSection section = optionalSection
                .OrElseGet(() => order.CreateOrderSection(product.SupplierId));

            section.Details.Add(new OrderDetail
            {
                Product = product,
                Quantity = quantity,
                State = OrderDetailState.Available
            });
        }
    }
}
