using FruitRacers.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlSupplierRepository : ReadOnlySqlRepository<Supplier>
    {
        public SqlSupplierRepository(FruitracersContext context)
            : base(context, q => q
                .Include(s => s.LogoImage)
                .Include(s => s.BackgroundImage)
                .Include(s => s.User)
                    .ThenInclude(s => s.Addresses))
        {
        }
    }
}
