using System;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class AuthenticationResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
    }
}