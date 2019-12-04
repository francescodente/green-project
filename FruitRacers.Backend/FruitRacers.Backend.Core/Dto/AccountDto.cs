namespace FruitRacers.Backend.Core.Dto
{
    public class AccountDto<TUser, TRole>
        where TUser : UserDto
        where TRole : RoleDto
    {
        public TUser User { get; set; }
        public TRole Role { get; set; }
    }
}
