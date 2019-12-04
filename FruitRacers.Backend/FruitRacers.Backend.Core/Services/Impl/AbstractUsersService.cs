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
    public abstract class AbstractUsersService<TRole, TEntity> : AbstractService, IUsersService<TRole>
        where TRole : RoleDto
        where TEntity : class
    {
        private readonly IAuthenticationHandler auth;

        public AbstractUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper)
        {
            this.auth = auth;
        }

        public async Task<int> Register(RegistrationDto<TRole> registration)
        {
            TEntity entity = this.CreateEntityFromAccount(registration.Account);
            this.auth.AssignPassword(this.ExtractUser(entity), registration.Password);
            await this.GetRepository().Insert(entity);
            await this.Session.SaveChanges();
            return this.ExtractUser(entity).UserId;
        }

        public async Task DeleteUser(int userID)
        {
            await this.GetRepository().DeleteWhere(UserIdIsEqualTo(userID));
            await this.Session.SaveChanges();
        }

        public async Task<AccountDto<LoggedInUserDto, TRole>> GetUserData(int userID)
        {
            TEntity entity = await this.RequireAccount(userID);
            return new AccountDto<LoggedInUserDto, TRole>
            {
                User = this.Mapper.Map<LoggedInUserDto>(this.ExtractUser(entity)),
                Role = this.Mapper.Map<TRole>(entity)
            };
        }

        public async Task UpdateUser(AccountDto<LoggedInUserDto, TRole> account)
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

        private void ApplyChangesToEntity(AccountDto<LoggedInUserDto, TRole> account, TEntity entity)
        {
            User userEntity = this.ExtractUser(entity);
            userEntity.MarketingConsent = account.User.MarketingConsent;
            userEntity.CookieConsent = account.User.CookieConsent;
            userEntity.Telephone = account.User.Telephone;
            userEntity.Email = account.User.Email;
            this.ApplyRoleChangesToEntity(account.Role, entity);
        }

        private TEntity CreateEntityFromAccount(AccountDto<SimpleUserDto, TRole> account)
        {
            User userEntity = new User
            {
                IsDeleted = false,
                IsEnabled = true,
                Email = account.User.Email,
                Telephone = account.User.Telephone,
                CookieConsent = account.User.CookieConsent,
                MarketingConsent = account.User.MarketingConsent
            };
            return this.CreateEntity(account.Role, userEntity);
        }

        protected abstract IRepository<TEntity> GetRepository();

        protected abstract Expression<Func<TEntity, bool>> UserIdIsEqualTo(int userId);

        protected abstract User ExtractUser(TEntity entity);

        protected abstract void ApplyRoleChangesToEntity(TRole role, TEntity entity);

        protected abstract TEntity CreateEntity(TRole role, User userEntity);
    }
}
