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
                .Include(user => user.Person)
                .Include(user => user.CustomerBusiness)
                .Include(user => user.Supplier)
                .Include(user => user.Administrator)
                .Include(user => user.DeliveryCompany));
            return this;
        }
    }
}
