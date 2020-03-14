using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IUserRepository IncludingRoles();

        IUserRepository IncludingAddresses();
    }
}
