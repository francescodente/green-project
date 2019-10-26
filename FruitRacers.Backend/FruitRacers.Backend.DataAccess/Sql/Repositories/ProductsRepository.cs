using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class ProductsRepository : SqlRepository<Product>, IProductsRepository
    {
        public ProductsRepository(FruitracersContext context) : base(context)
        {
            this.ChainQueryModification(q => q.Include(p => p.ProductCategories));
        }

        public IProductsRepository IncludingPrices()
        {
            this.ChainQueryModification(q => q.Include(p => p.Prices));
            return this;
        }
    }
}
