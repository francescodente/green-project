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
            : base(context, q => q.Include(p => p.ProductCategories))
        {
        }

        public IProductRepository BelongingTo(int supplierID)
        {
            this.ChainQueryModification(q => q.Where(p => p.SupplierId == supplierID));
            return this;
        }

        public IProductRepository IncludingPrices()
        {
            this.ChainQueryModification(q => q.Include(p => p.Prices));
            return this;
        }
    }
}
