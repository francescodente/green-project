namespace FruitRacers.Backend.Contracts.Users.Roles
{
    public class AdministratorDto : RoleDto
    {
        public override RoleTypeDto RoleType => RoleTypeDto.Administrator;
    }
}
