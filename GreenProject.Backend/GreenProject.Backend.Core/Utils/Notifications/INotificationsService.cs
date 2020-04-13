using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Notifications
{
    public interface INotificationsService
    {
        Task OrderReceived(Order order);

        Task OrderStateChanged(Order order, OrderState oldState);
    }
}
