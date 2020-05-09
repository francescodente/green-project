namespace GreenProject.Backend.ApiLayer.Authentication
{
    public class CookieSettings
    {
        public string Path { get; set; }
        public bool Secure { get; set; }
        public bool HttpOnly { get; set; }
    }
}