using FruitRacers.Backend.Core.Entities;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils.Notifications
{
    public interface INotificationsService
    {
        Task OrderReceived(OrderSection order);

        Task SupplierRegistered(User supplier, string generatedPassword);
    }
}
