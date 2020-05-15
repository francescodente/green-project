using GreenProject.Backend.Contracts.Orders;
using GreenProject.Backend.Contracts.PurchasableItems;
using GreenProject.Backend.Contracts.WeeklyOrders;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IWeeklyOrdersService
    {
        Task<WeeklyOrderDto> Subscribe(int userId, DeliveryInfoDto.Input deliveryInfo);

        Task Unsubscribe(int userId);

        Task<WeeklyOrderDto> GetWeeklyOrderData(int userId);

        Task AddCrate(int userId, int crateId);

        Task AddExtraProduct(int userId, QuantifiedProductDto.Input product);

        Task UpdateExtraProduct(int userId, QuantifiedProductDto.Input product);

        Task RemoveItem(int userId, int orderDetailId);

        Task AddProductToCrate(int userId, int orderDetailId, QuantifiedProductDto.Input insertion);

        Task RemoveProductFromCrate(int userId, int orderDetailId, int productId);

        Task UpdateProductInCrate(int userId, int orderDetailId, QuantifiedProductDto.Input update);

        Task SkipWeeks(int userId, int weeks);

        Task UpdateDeliveryInfo(int userId, DeliveryInfoDto.Input deliveryInfo);
    }
}
