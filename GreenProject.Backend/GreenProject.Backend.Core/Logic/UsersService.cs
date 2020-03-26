using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
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
            User userEntity = await this.RequireUserById(userId);
            userEntity.IsDeleted = true;
            await this.Data.SaveChangesAsync();
        }

        public async Task<UserOutputDto> GetUserData(int userId)
        {
            User userEntity = await this.RequireUserById(userId, r => r
                .IncludingAddresses()
                .IncludingRoles());
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
