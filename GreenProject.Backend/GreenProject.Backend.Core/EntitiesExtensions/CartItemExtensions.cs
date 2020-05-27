using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Core.EntitiesExtensions
{
    public static class CartItemExtensions
    {
        public static OrderDetail CreateOrderDetail(this CartItem item)
        {
            return new OrderDetail
            {
                Item = item.Product,
                Quantity = item.Quantity,
                Price = item.Product.Price
            };
        }
    }
}
