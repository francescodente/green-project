using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class UsersService : AbstractService, IUsersService
    {
        public UsersService(IRequestSession request)
            : base(request)
        {

        }

        public async Task DeleteUser(int userId)
        {
            User userEntity = await RequireUserById(userId);
            userEntity.IsDeleted = true;
            await Data.SaveChangesAsync();
        }

        public async Task<UserDto.Output> GetUserData(int userId)
        {
            User userEntity = await RequireUserById(userId, r => r
                .IncludingAddresses()
                .IncludingRoles());
            return Mapper.Map<UserDto.Output>(userEntity);
        }
    }
}
