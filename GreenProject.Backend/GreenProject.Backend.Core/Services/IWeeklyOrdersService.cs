using GreenProject.Backend.Contracts.Cart;
using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.WeeklyOrders;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IWeeklyOrdersService
    {
        Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoInputDto deliveryInfo);

        Task Unsubscribe(int userId);

        Task<WeeklyOrderDto> GetWeeklyOrderData(int userId);

        Task AddCrate(int userId, int crateId);

        Task AddExtraProduct(int userId, QuantifiedProductInputDto product);

        Task RemoveItem(int userId, int orderDetailId);

        Task AddProductToCrate(int userId, int orderDetailId, QuantifiedProductInputDto insertion);

        Task RemoveProductFromCrate(int userId, int orderDetailId, int productId);

        Task UpdateProductInCrate(int userId, int orderDetailId, QuantifiedProductInputDto update);

        Task SkipWeeks(int userId, int weeks);

        Task UpdateDeliveryInfo(int userId, DeliveryInfoInputDto deliveryInfo);
    }
}
