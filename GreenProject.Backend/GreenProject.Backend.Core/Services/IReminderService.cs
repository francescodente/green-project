using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IReminderService
    {
        Task CheckSubscriptionReminders(TimeSpan anticipationTime);
    }
}
