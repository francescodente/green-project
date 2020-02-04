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

        private async Task<User> RequireUser(int userId, Func<IUserRepository, IUserRepository> repositoryWrapper = null)
        {
            IUserRepository repository = this.Data.Users;
            repository = repositoryWrapper != null ? repositoryWrapper(repository) : repository;
            return await repository
                .FindOne(u => u.UserId == userId)
                .Then(u => u.OrElseThrow(() => UserNotFoundException.WithId(userId)));
        }

        public async Task DeleteUser(int userId)
        {
            User userEntity = await this.RequireUser(userId);
            userEntity.IsDeleted = true;
            await this.Data.SaveChanges();
        }

        public async Task<UserOutputDto> GetUserData(int userId)
        {
            User userEntity = await this.RequireUser(userId, r => r.IncludingRoles());
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
