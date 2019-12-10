using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IUsersService<TRole>
        where TRole : RoleDto
    {
        Task<int> Register(RegistrationDto<TRole> registration);

        Task<AccountOutputDto<TRole>> GetUserData(int userId);

        Task UpdateUser(int userId, AccountInputDto<TRole> account);

        Task DeleteUser(int userId);
    }
}
