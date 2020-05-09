using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System.Linq;
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

        public async Task<UserDto.Output> GetUserData(int userId)
        {
            User userEntity = await this.RequireUserById(userId, r => r
                .IncludingAddresses()
                .IncludingRoles());
            return this.Mapper.Map<UserDto.Output>(userEntity);
        }
    }
}
