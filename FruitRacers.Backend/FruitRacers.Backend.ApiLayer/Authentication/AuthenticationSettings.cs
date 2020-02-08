using System;

namespace FruitRacers.Backend.ApiLayer.Authentication
{
    public class AuthenticationSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenDuration { get; set; }
        public PasswordGenerationSettings PasswordGeneration { get; set; }
    }
}
