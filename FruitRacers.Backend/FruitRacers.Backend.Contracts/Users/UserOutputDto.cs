using FruitRacers.Backend.Contracts.Users.Roles;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Users
{
    public class UserOutputDto : AbstractUserDto
    {
        public int UserId { get; set; }
        public IEnumerable<RoleTypeDto> RoleNames { get; set; }
        public IDictionary<RoleTypeDto, RoleDto> RolesData { get; set; }
    }
}
