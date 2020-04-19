using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class AuthenticationResultDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public IEnumerable<RoleType> Roles { get; set; }
    }
}