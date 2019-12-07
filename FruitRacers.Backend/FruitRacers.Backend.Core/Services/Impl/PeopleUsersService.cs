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
    public class PeopleUsersService : AbstractUsersService<PersonDto, Person>
    {
        public PeopleUsersService(IDataSession session, IMapper mapper, IAuthenticationHandler auth)
            : base(session, mapper, auth)
        {
        }

        protected override void ApplyRoleChangesToEntity(PersonDto role, Person entity)
        {
            entity.Cf = role.Cf;
            entity.BirthDate = role.BirthDate;
            entity.FirstName = role.FirstName;
            entity.LastName = role.LastName;
        }

        protected override Person CreateEntity(PersonDto role, User userEntity)
        {
            return new Person
            {
                BirthDate = role.BirthDate,
                Cf = role.Cf,
                FirstName = role.FirstName,
                LastName = role.LastName,
                User = userEntity
            };
        }

        protected override User ExtractUser(Person entity)
        {
            return entity.User;
        }

        protected override IRepository<Person> GetRepository()
        {
            return this.Session.People;
        }

        protected override Expression<Func<Person, bool>> UserIdIsEqualTo(int userId)
        {
            return u => u.UserId == userId;
        }
    }
}
