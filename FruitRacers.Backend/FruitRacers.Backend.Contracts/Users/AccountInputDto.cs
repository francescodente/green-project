using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.Contracts.Users
{
    public class AccountInputDto<TRole>
        where TRole : RoleDto
    {
        public UserInputDto User { get; set; }
        public TRole Role { get; set; }
    }
}
