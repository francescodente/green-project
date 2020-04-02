using GreenProject.Backend.Contracts.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IWeeklyOrdersService
    {
        Task Subscribe(int userId, DeliveryInfoInputDto deliveryInfo);

        Task Unsubscribe(int userId);

        Task AddCrate(int userId, int crateId);

        Task RemoveCrate(int userId, int crateId);
    }
}
