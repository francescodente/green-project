using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Session;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
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
            await this.Data.SaveChanges();
        }

        public async Task<UserOutputDto> GetUserData(int userId)
        {
            User userEntity = await this.RequireUserById(userId, r => r.IncludingRoles());
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
