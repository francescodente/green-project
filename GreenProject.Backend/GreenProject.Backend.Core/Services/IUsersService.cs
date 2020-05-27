using GreenProject.Backend.Contracts.Users;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IUsersService
    {
        Task<UserDto.Output> GetUserData(int userId);

        Task DeleteUser(int userId);
    }
}
