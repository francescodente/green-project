using GreenProject.Backend.Core.Utils.Email;

namespace GreenProject.Backend.Infrastructure.Notifications
{
    public class MailNotificationDescription
    {
        public string Subject { get; set; }
        public string BodyTemplateFile { get; set; }
        public MailContext Context { get; set; }
    }
}
