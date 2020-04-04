namespace GreenProject.Backend.Infrastructure.Notifications
{
    public class MailNotificationsSettings
    {
        public MailNotificationDescription OrderReceived { get; set; }
        public MailNotificationDescription OrderShipped { get; set; }
        public MailNotificationDescription OrderCompleted { get; set; }
        public MailNotificationDescription OrderCanceled { get; set; }
    }
}
