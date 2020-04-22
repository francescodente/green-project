using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Notifications
{
    public interface INotificationsService
    {
        Task OrderAccepted(Order order);

        Task OrderReceived(Order order);

        Task OrderStateChanged(Order order, OrderState oldState);

        Task UserSubscribed(User user);

        Task UserUnsubscribed(User user);

        Task WeeklyOrderReminder(User user);
    }
}
