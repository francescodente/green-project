namespace GreenProject.Backend.Infrastructure.Notifications.Mail
{
    public class MailDescription
    {
        public string Subject { get; set; }
        public string BodyTemplateFile { get; set; }
        public MailContext Context { get; set; }
    }
}
