using AutoMapper;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Utils;
using System;
using System.Linq.Expressions;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CustomerBusinessUsersService : AbstractUsersService<CustomerBusinessDto, CustomerBusiness>
    {
        public CustomerBusinessUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper, auth)
        {
        }

        protected override void ApplyRoleChangesToEntity(CustomerBusinessDto role, CustomerBusiness entity)
        {
            entity.BusinessName = role.BusinessName;
            entity.LegalForm = role.LegalForm;
            entity.Pec = role.Pec;
            entity.Sdi = role.Sdi;
            entity.VatNumber = role.VatNumber;
        }

        protected override CustomerBusiness CreateEntity(CustomerBusinessDto role, User userEntity)
        {
            return new CustomerBusiness
            {
                BusinessName = role.BusinessName,
                LegalForm = role.LegalForm,
                Pec = role.Pec,
                Sdi = role.Sdi,
                VatNumber = role.VatNumber,
                IsValid = true,
                User = userEntity
            };
        }

        protected override User ExtractUser(CustomerBusiness entity)
        {
            return entity.User;
        }

        protected override IRepository<CustomerBusiness> GetRepository()
        {
            return this.Session.CustomerBusinesses;
        }

        protected override Expression<Func<CustomerBusiness, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
