using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IReminderService
    {
        Task CheckSubscriptionReminders(TimeSpan anticipationTime);
    }
}
