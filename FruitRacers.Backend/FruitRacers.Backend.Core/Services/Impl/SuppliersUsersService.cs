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
    public class SuppliersUsersService : AbstractUsersService<SupplierDto, Supplier>
    {
        public SuppliersUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper, auth)
        {
        }

        protected override void ApplyRoleChangesToEntity(SupplierDto role, Supplier entity)
        {
            entity.Description = role.Description;
            entity.BusinessName = role.BusinessName;
            entity.LegalForm = role.LegalForm;
            entity.Pec = role.Pec;
            entity.Sdi = role.Sdi;
            entity.VatNumber = role.VatNumber;
        }

        protected override Supplier CreateEntity(SupplierDto role, User userEntity)
        {
            if (role.Address != null)
            {
                userEntity.Addresses.Add(new Address
                {
                    Description = role.Address.Description,
                    Latitude = role.Address.Latitude,
                    Longitude = role.Address.Longitude
                });
            }
            return new Supplier
            {
                Description = role.Description,
                BusinessName = role.BusinessName,
                LegalForm = role.LegalForm,
                Pec = role.Pec,
                Sdi = role.Sdi,
                VatNumber = role.VatNumber,
                IsValid = true,
                User = userEntity
            };
        }

        protected override User ExtractUser(Supplier entity)
        {
            return entity.User;
        }

        protected override IRepository<Supplier> GetRepository()
        {
            return this.Session.Suppliers;
        }

        protected override Expression<Func<Supplier, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
