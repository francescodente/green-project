using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlUserRepository : SqlRepository<User>, IUserRepository
    {
        public SqlUserRepository(FruitracersContext context)
            : base(context)
        {
        }

        public IUserRepository IncludingRoles()
        {
            this.ChainQueryModification(q => q
                .Include(user => user.UserPerson)
                .Include(user => user.UserBusiness)
                    .ThenInclude(business => business.UserBusinessCustomer)
                .Include(user => user.UserBusiness)
                    .ThenInclude(business => business.UserBusinessSupplier));
            return this;
        }
    }
}
