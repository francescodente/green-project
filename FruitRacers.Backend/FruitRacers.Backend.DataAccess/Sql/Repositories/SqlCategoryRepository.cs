using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlCategoryRepository : ReadOnlySqlRepository<Category>
    {
        public SqlCategoryRepository(FruitracersContext context)
            : base(context, q => q.Include(c => c.Image))
        {
        }
    }
}
