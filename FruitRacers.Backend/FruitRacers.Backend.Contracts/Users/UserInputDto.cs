using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.Contracts.Users
{
    public class UserInputDto<TRole> : AbstractUserDto
        where TRole : RoleDto
    {
        public TRole Role { get; set; }
    }
}
