using System;

namespace FruitRacers.Backend.Core.Dto
{
    public class AuthenticationResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserID { get; set; }
    }
}