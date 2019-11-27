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
    public class PeopleUsersService : AbstractUsersService<PersonDto, UserPerson>
    {
        public PeopleUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler authenticationHandler)
            : base(session, mapper, authenticationHandler)
        {
        }

        protected override void ApplyChangesToEntity(PersonDto dto, UserPerson entity)
        {
            throw new NotImplementedException();
        }

        protected override User ExtractUser(UserPerson entity)
        {
            return entity.User;
        }

        protected override IRepository<UserPerson> GetRepository()
        {
            return this.Session.People;
        }

        protected override Expression<Func<UserPerson, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
