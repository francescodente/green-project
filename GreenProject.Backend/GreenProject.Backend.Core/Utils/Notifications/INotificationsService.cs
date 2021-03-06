using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Notifications
{
    public interface INotificationsService
    {
        Task AccountConfirmation(User user, string token);

        Task PasswordRecovery(User user, string token);

        Task PasswordRecoveryAlt(string email);

        Task SupportRequested(string senderEmail, string subject, string body);

        Task OrderAccepted(Order order);

        Task OrderStateChanged(Order order, OrderState oldState);

        Task UserSubscribed(User user);

        Task UserUnsubscribed(User user);

        Task SubscriptionReminder(Order order);
    }
}
