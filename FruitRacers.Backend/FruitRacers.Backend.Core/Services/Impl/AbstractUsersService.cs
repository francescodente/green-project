using AutoMapper;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Utils;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task DeleteUser(int userId)
        {
            await this.GetRepository().DeleteWhere(UserIdIsEqualTo(userId));
            await this.Session.SaveChanges();
        }

        public async Task<AccountOutputDto<TRole>> GetUserData(int userID)
        {
            TEntity entity = await this.RequireAccount(userID);
            User userEntity = this.ExtractUser(entity);
            TRole role = this.Mapper.Map<TRole>(entity);
            return new AccountOutputDto<TRole>
            {
                User = this.Mapper.Map<UserOutputDto>(userEntity),
                PrimaryRole = role,
                OtherRoles = this.GetRoleDtos(userEntity).Where(r => r.RoleType != role.RoleType)
            };
        }

        private IEnumerable<RoleDto> GetRoleDtos(User user)
        {
            if (user.Administrator != null)
            {
                yield return this.Mapper.Map<AdministratorDto>(user.Administrator);
            }
            if (user.DeliveryCompany != null)
            {
                yield return this.Mapper.Map<DeliveryCompanyDto>(user.DeliveryCompany);
            }
            if (user.Person != null)
            {
                yield return this.Mapper.Map<PersonDto>(user.Person);
            }
            if (user.CustomerBusiness != null)
            {
                yield return this.Mapper.Map<CustomerBusinessDto>(user.CustomerBusiness);
            }
            if (user.Supplier != null)
            {
                yield return this.Mapper.Map<SupplierDto>(user.Supplier);
            }
        }

        public async Task UpdateUser(int userId, AccountInputDto<TRole> account)
        {
            await this.GetRepository().UpdateWhere(
                UserIdIsEqualTo(userId),
                entity => this.ApplyChangesToEntity(account, entity));
            await this.Session.SaveChanges();
        }

        private async Task<TEntity> RequireAccount(int userId)
        {
            return await this.GetRepository()
                .FindOne(this.UserIdIsEqualTo(userId))
                .Then(u => u.Value);
        }

        private void ApplyChangesToEntity(AccountInputDto<TRole> account, TEntity entity)
        {
            User userEntity = this.ExtractUser(entity);
            userEntity.MarketingConsent = account.User.MarketingConsent;
            userEntity.CookieConsent = account.User.CookieConsent;
            userEntity.Telephone = account.User.Telephone;
            userEntity.Email = account.User.Email;
            this.ApplyRoleChangesToEntity(account.Role, entity);
        }

        private TEntity CreateEntityFromAccount(AccountInputDto<TRole> account)
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
