using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IUsersService
    {
        Task<UserDto.Output> GetUserData(int userId);

        Task DeleteUser(int userId);
    }
}
