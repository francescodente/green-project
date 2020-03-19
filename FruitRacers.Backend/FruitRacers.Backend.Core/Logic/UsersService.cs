using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils.Session;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
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
