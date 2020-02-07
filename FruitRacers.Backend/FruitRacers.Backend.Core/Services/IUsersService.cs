using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IUsersService
    {
        Task<UserOutputDto> GetUserData(int userId);

        Task DeleteUser(int userId);
    }
}
