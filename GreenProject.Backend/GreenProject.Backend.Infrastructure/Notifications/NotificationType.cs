using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public enum NotificationType
    {
        AccountConfirmation,
        PasswordRecovery,
        PasswordRecoveryAlt,
        OrderSummary,
        OrderShipped,
        OrderCompleted,
        OrderCanceled,
        UserSubscribed,
        UserUnsubscribed,
        SubscriptionReminder,
        SupportRequest
    }
}
