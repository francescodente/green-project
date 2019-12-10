using FruitRacers.Backend.Contracts.Orders;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ICartService
    {
        Task<CartOutputDto> GetCartDetailsForUser(int userId);

        Task UpdateCartDeliveryInfoForUser(int userId, DeliveryInfoInputDto deliveryInfo);

        Task InsertCartItemForUser(int userId, CartItemInputDto insertion);

        Task UpdateCartItemForUser(int userId, CartItemInputDto insertion);

        Task DeleteCartItemForUser(int userId, int productId);

        Task<int> ConfirmCartForUser(int userId);
    }
}
