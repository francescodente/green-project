using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Pricing;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenProject.Backend.Core.EntitiesExtensions
{
    public static class OrdersExtensions
    {
        private static IDictionary<OrderState, ISet<OrderState>> validStateTransitions;

        static OrdersExtensions()
        {
            validStateTransitions = new Dictionary<OrderState, ISet<OrderState>>
            {
                { OrderState.Pending, new HashSet<OrderState> { OrderState.Shipping, OrderState.Canceled } },
                { OrderState.Shipping, new HashSet<OrderState> { OrderState.Completed } },
                { OrderState.Completed, new HashSet<OrderState> { } },
                { OrderState.Canceled, new HashSet<OrderState> { } }
            };
        }

        public static void ChangeState(this Order order, OrderState newState)
        {
            if (!validStateTransitions[order.OrderState].Contains(newState))
            {
                throw new InvalidStateChangeException(order.OrderState, newState);
            }

            order.OrderState = newState;
        }

        public static OrderDetail CreateCopy(this OrderDetail detail)
        {
            OrderDetail copy = new OrderDetail
            {
                ItemId = detail.ItemId,
                Quantity = detail.Quantity,
                Price = detail.Item.Price
            };

            detail.SubProducts
                .Select(CreateCopy)
                .ForEach(copy.SubProducts.Add);

            return copy;
        }

        private static OrderDetailSubProduct CreateCopy(this OrderDetailSubProduct subProduct)
        {
            return new OrderDetailSubProduct
            {
                ProductId = subProduct.ProductId,
                Quantity = subProduct.Quantity
            };
        }

        public static void AddSubProduct(this OrderDetail detail, int productId, int quantity)
        {
            detail.ChangeProductQuantity(productId, old => old + quantity);
        }

        public static void UpdateSubProductQuantity(this OrderDetail detail, int productId, int newQuantity)
        {
            detail.ChangeProductQuantity(productId, old =>
            {
                if (old == 0)
                {
                    throw NotFoundException.PurchasableItemWithId(productId);
                }
                return newQuantity;
            });
        }

        public static void DeleteSubProduct(this OrderDetail detail, int productId)
        {
            detail.ChangeProductQuantity(productId, old =>
            {
                if (old == 0)
                {
                    throw NotFoundException.PurchasableItemWithId(productId);
                }
                return 0;
            });
        }

        private static void ChangeProductQuantity(this OrderDetail detail, int productId, Func<int, int> quantitySupplier)
        {
            IOptional<OrderDetailSubProduct> current = detail.SubProducts
                .SingleOptional(p => p.ProductId == productId);

            CrateCompatibility compatibility = (detail.Item as Crate)
                .Compatibilities
                .SingleOptional(c => c.CrateId == detail.ItemId && c.ProductId == productId)
                .OrElseThrow(() => new IncompatibleProductException());

            int oldQuantity = current.Map(c => c.Quantity).OrElse(0);
            int newQuantity = quantitySupplier(oldQuantity);
            int actualQuantity = compatibility.Product.CrateMultiplier * newQuantity;

            if (actualQuantity > detail.RemainingSlots || newQuantity > compatibility.Maximum.GetValueOrDefault(int.MaxValue))
            {
                throw new InvalidQuantityException();
            }

            if (current.IsPresent())
            {
                if (newQuantity == 0)
                {
                    detail.SubProducts.Remove(current.Value);
                }
                else
                {
                    current.Value.Quantity = newQuantity;
                }
            }
            else
            {
                detail.SubProducts.Add(new OrderDetailSubProduct
                {
                    ProductId = productId,
                    Quantity = newQuantity
                });
            }

            detail.RemainingSlots -= (newQuantity - oldQuantity) * compatibility.Product.CrateMultiplier;
        }
    }
}
