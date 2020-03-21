using FruitRacers.Backend.Contracts.Users.Roles;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Users
{
    public class UserOutputDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
        public IEnumerable<RoleTypeDto> Roles { get; set; }
        public IDictionary<RoleTypeDto, RoleDto> RolesData { get; set; }
        public bool ShouldChangePassword { get; set; }
    }
}
