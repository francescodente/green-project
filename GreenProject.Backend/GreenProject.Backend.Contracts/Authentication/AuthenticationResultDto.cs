using GreenProject.Backend.Entities;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class AuthenticationResultDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public IEnumerable<RoleType> Roles { get; set; }
    }
}