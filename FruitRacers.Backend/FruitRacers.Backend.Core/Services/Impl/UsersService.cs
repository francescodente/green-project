using AutoMapper;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class UsersService : AbstractService, IUsersService
    {
        public UsersService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {

        }

        public async Task DeleteUser()
        {
            User userEntity = await this.Session
                .Users
                .FindOne(u => u.UserId == this.RequestingUser.UserId)
                .Then(u => u.OrElseThrow(() => UserNotFoundException.WithId(this.RequestingUser.UserId)));
            userEntity.IsDeleted = true;
            await this.Session.SaveChanges();
        }

        public async Task<UserOutputDto> GetUserData()
        {
            User userEntity = await this.Session
                .Users
                .IncludingRoles()
                .FindOne(u => u.UserId == this.RequestingUser.UserId)
                .Then(u => u.OrElseThrow(() => UserNotFoundException.WithId(this.RequestingUser.UserId)));
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
