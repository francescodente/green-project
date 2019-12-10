using FruitRacers.Backend.Contracts.Users.Roles;
using System.Collections.Generic;

namespace FruitRacers.Backend.Contracts.Users
{
    public class AccountOutputDto<TRole>
        where TRole : RoleDto
    {
        public UserOutputDto User { get; set; }
        public TRole PrimaryRole { get; set; }
        public IEnumerable<RoleDto> OtherRoles { get; set; }
    }
}
