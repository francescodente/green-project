namespace GreenProject.Backend.Contracts.Support
{
    public class SupportRequestDto
    {
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
