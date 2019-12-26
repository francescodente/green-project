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

        private SqlUserRepository(FruitracersContext context, Func<IQueryable<User>, IQueryable<User>> initialModifier)
            : base(context, initialModifier)
        {
        }

        private IUserRepository WrapRepository(Func<IQueryable<User>, IQueryable<User>> modifier)
        {
            return new SqlUserRepository(this.Context, this.WrapQuery(modifier));
        }

        public IUserRepository IncludingRoles()
        {
            return this.WrapRepository(q => q
                .Include(user => user.Person)
                .Include(user => user.CustomerBusiness)
                .Include(user => user.Supplier)
                .Include(user => user.Administrator)
                .Include(user => user.DeliveryCompany));
        }
    }
}
