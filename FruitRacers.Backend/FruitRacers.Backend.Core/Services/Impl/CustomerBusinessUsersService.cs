using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using FruitRacers.Backend.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class CustomerBusinessUsersService : AbstractUsersService<CustomerBusinessDto, UserBusinessCustomer>
    {
        public CustomerBusinessUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper, auth)
        {
        }

        protected override void ApplyRoleChangesToEntity(CustomerBusinessDto role, UserBusinessCustomer entity)
        {
            entity.User.BusinessName = role.BusinessName;
            entity.User.LegalForm = role.LegalForm;
            entity.User.Pec = role.Pec;
            entity.User.Sdi = role.Sdi;
            entity.User.VatNumber = role.VatNumber;
        }

        protected override UserBusinessCustomer CreateEntity(CustomerBusinessDto role, User userEntity)
        {
            return new UserBusinessCustomer
            {
                User = new UserBusiness
                {
                    BusinessName = role.BusinessName,
                    LegalForm = role.LegalForm,
                    Pec = role.Pec,
                    Sdi = role.Sdi,
                    VatNumber = role.VatNumber,
                    IsValid = true,
                    User = userEntity
                }
            };
        }

        protected override User ExtractUser(UserBusinessCustomer entity)
        {
            return entity.User.User;
        }

        protected override IRepository<UserBusinessCustomer> GetRepository()
        {
            return this.Session.CustomerBusinesses;
        }

        protected override Expression<Func<UserBusinessCustomer, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
