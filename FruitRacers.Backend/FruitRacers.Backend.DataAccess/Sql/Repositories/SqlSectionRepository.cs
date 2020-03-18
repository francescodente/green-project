using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlSectionRepository : ReadOnlySqlRepository<OrderSection>, ISectionRepository
    {
        public SqlSectionRepository(FruitracersContext context)
            : base(context, q => q.Include(s => s.Order))
        {
        }

        public ISectionRepository WithState(OrderSectionState state)
        {
            throw new NotImplementedException();
        }
    }
}
