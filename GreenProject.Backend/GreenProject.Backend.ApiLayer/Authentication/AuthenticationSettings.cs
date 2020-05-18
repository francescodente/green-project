using System;

namespace GreenProject.Backend.ApiLayer.Authentication
{
    public class AuthenticationSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenDuration { get; set; }
        public TimeSpan RefreshTokenDuration { get; set; }
        public TimeSpan ConfirmationTokenDuration { get; set; }
        public TimeSpan PasswordRecoveryTokenDuration { get; set; }
        public PasswordGenerationSettings PasswordGeneration { get; set; }
        public CookieSettings CookieSettings { get; set; }
    }
}
