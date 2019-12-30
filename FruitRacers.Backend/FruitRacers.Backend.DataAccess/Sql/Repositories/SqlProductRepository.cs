using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlProductRepository : SqlRepository<Product>, IProductRepository
    {
        public SqlProductRepository(FruitracersContext context)
            : this(context, q => q
                .Include(p => p.Prices)
                .Include(p => p.Category))
        {
        }

        private SqlProductRepository(FruitracersContext context, Func<IQueryable<Product>, IQueryable<Product>> initialModifier)
            : base(context, initialModifier)
        {
        }

        private IProductRepository WrapRepository(Func<IQueryable<Product>, IQueryable<Product>> modifier)
        {
            return new SqlProductRepository(this.Context, this.WrapQuery(modifier));
        }

        public IProductRepository BelongingTo(int supplierID)
        {
            return this.WrapRepository(q => q.Where(p => p.SupplierId == supplierID));
        }

        public IProductRepository IncludingPrices()
        {
            return this.WrapRepository(q => q.Include(p => p.Prices));
        }
    }
}
