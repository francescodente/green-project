using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
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

        public Task<UserOutputDto> GetUserData(int userId)
        {
            return this.Data
                .Users
                .Where(u => u.UserId == userId)
                .ProjectTo<UserOutputDto>(this.Mapper.ConfigurationProvider)
                .SingleOptionalAsync()
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithId(userId)));
        }
    }
}
