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
        public CustomerBusinessUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler authenticationHandler)
            : base(session, mapper, authenticationHandler)
        {
        }

        protected override void ApplyChangesToEntity(CustomerBusinessDto dto, UserBusinessCustomer entity)
        {
            throw new NotImplementedException();
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
