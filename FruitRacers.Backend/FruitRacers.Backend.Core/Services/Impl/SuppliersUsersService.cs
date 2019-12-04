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
    public class SuppliersUsersService : AbstractUsersService<SupplierDto, UserBusinessSupplier>
    {
        public SuppliersUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper, auth)
        {
        }

        protected override void ApplyRoleChangesToEntity(SupplierDto role, UserBusinessSupplier entity)
        {
            entity.Description = role.Description;
            entity.User.BusinessName = role.BusinessName;
            entity.User.LegalForm = role.LegalForm;
            entity.User.Pec = role.Pec;
            entity.User.Sdi = role.Sdi;
            entity.User.VatNumber = role.VatNumber;
        }

        protected override UserBusinessSupplier CreateEntity(SupplierDto role, User userEntity)
        {
            return new UserBusinessSupplier
            {
                Description = role.Description,
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

        protected override User ExtractUser(UserBusinessSupplier entity)
        {
            return entity.User.User;
        }

        protected override IRepository<UserBusinessSupplier> GetRepository()
        {
            return this.Session.Suppliers;
        }

        protected override Expression<Func<UserBusinessSupplier, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
