using GreenProject.Backend.Contracts.Categories;
using GreenProject.Backend.Contracts.PurchasableItems;

namespace GreenProject.Backend.Contracts.Cart
{
    public class CartItemOutputDto
    {
        public ProductOutputDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
