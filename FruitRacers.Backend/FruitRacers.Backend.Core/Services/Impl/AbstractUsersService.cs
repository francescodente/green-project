using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Utils;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public abstract class AbstractUsersService<TDto, TEntity> : AbstractService, IUsersService<TDto>
        where TDto : AccountDto
        where TEntity : class
    {
        private readonly IAuthenticationHandler authenticationHandler;

        public AbstractUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler authenticationHandler)
            : base(session, mapper)
        {
            this.authenticationHandler = authenticationHandler;
        }

        public async Task DeleteUser(int userID)
        {
            await this.GetRepository().DeleteWhere(UserIdIsEqualTo(userID));
            await this.Session.SaveChanges();
        }

        public async Task<TDto> GetUserData(int userID)
        {
            TEntity entity = await this.RequireAccount(userID);
            return this.Mapper.Map<TDto>(entity);
        }

        public async Task<int> Register(RegistrationDto<TDto> registration)
        {
            TEntity entity = this.Mapper.Map<TEntity>(registration.Account);
            this.authenticationHandler.AssignPassword(this.ExtractUser(entity), registration.Password);
            await this.GetRepository().Insert(entity);
            await this.Session.SaveChanges();
            return this.ExtractUser(entity).UserId;
        }

        public async Task UpdateUser(TDto account)
        {
            await this.GetRepository().UpdateWhere(
                UserIdIsEqualTo(account.User.UserId),
                entity => this.ApplyChangesToEntity(account, entity));
            await this.Session.SaveChanges();
        }

        private async Task<TEntity> RequireAccount(int userId)
        {
            return await this.GetRepository()
                .FindOne(this.UserIdIsEqualTo(userId))
                .Then(u => u.Value);
        }

        protected abstract IRepository<TEntity> GetRepository();

        protected abstract Expression<Func<TEntity, bool>> UserIdIsEqualTo(int userId);

        protected abstract User ExtractUser(TEntity entity);

        protected abstract void ApplyChangesToEntity(TDto dto, TEntity entity);
    }
}
