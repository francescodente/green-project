using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.WeeklyOrders;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IWeeklyOrdersService
    {
        Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo);

        Task<WeeklyOrderDto> GetWeeklyOrderData(int userId);

        Task Unsubscribe(int userId);

        Task AddCrate(int userId, int crateId);

        Task RemoveCrate(int userId, int crateId);

        Task AddProductToCrate(int userId, int bookedCrateId, CartItemInputDto insertion);

        Task RemoveProductFromCrate(int userId, int bookedCrateId, int productId);

        Task UpdateProductInCrate(int userId, int bookedCrateId, CartItemInputDto update);


    }
}
