using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Entities;
using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Users
{
    public static class UserDto
    {
        public class Output
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public bool MarketingConsent { get; set; }
            public IDictionary<RoleType, RoleDto> RolesData { get; set; }
            public bool IsSubscribed { get; set; }
            public bool ShouldChangePassword { get; set; }
        }

        public class Input
        {
            public string Email { get; set; }
            public bool MarketingConsent { get; set; }
        }
    }
}
