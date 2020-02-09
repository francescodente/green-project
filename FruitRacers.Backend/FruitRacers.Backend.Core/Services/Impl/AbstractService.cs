using AutoMapper;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public abstract class AbstractService
    {
        protected IRequestSession Request { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected IDataSession Data => this.Request.Data;
        protected IUserSession RequestingUser => this.Request.User;

        public AbstractService(IRequestSession request, IMapper mapper)
        {
            this.Request = request;
            this.Mapper = mapper;
        }

        protected async Task<User> FindRequestingUser(Func<IUserRepository, IUserRepository> repositoryWrapper = null)
        {
            return await this.RequireUserById(this.RequestingUser.UserId, repositoryWrapper);
        }

        protected async Task<IOptional<User>> FindUserById(int userId, Func<IUserRepository, IUserRepository> repositoryWrapper = null)
        {
            IUserRepository repository = this.Data.Users;
            repository = repositoryWrapper is null ? repository : repositoryWrapper(repository);
            return await repository
                .FindOne(u => u.UserId == userId);
        }

        protected async Task<User> RequireUserById(int userId, Func<IUserRepository, IUserRepository> repositoryWrapper = null)
        {
            return await this.FindUserById(userId, repositoryWrapper)
                .Then(u => u.OrElseThrow(() => UserNotFoundException.WithId(userId)));
        }
    }
}
