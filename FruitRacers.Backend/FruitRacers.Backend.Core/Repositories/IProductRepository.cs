using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IProductRepository IncludingPrices();

        IProductRepository BelongingTo(int supplierID);
    }
}
