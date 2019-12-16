using AutoMapper;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class UsersService : AbstractService, IUsersService
    {
        public UsersService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {

        }

        public async Task DeleteUser(int userId)
        {
            await this.Session.Users.DeleteWhere(u => u.UserId == userId);
            await this.Session.SaveChanges();
        }

        public async Task<UserOutputDto> GetUserData(int userId)
        {
            User userEntity = await this.Session
                .Users
                .IncludingRoles()
                .FindOne(u => u.UserId == userId)
                .Then(u => u.OrElseThrow(() => new UserNotFoundException()));
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
