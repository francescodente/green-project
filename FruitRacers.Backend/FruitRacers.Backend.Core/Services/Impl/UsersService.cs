using AutoMapper;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class UsersService : AbstractService, IUsersService
    {
        public UsersService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
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
