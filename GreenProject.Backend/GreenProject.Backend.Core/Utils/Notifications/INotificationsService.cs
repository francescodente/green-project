using GreenProject.Backend.Core.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Notifications
{
    public interface INotificationsService
    {
        Task OrderReceived(OrderSection order);

        Task SupplierRegistered(User supplier, string generatedPassword);
    }
}
