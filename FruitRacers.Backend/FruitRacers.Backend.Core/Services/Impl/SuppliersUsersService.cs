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
        public SuppliersUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler authenticationHandler)
            : base(session, mapper, authenticationHandler)
        {
        }

        protected override void ApplyChangesToEntity(SupplierDto dto, UserBusinessSupplier entity)
        {
            throw new NotImplementedException();
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
