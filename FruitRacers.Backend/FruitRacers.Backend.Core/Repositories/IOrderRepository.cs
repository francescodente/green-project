using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IOrderRepository IncludingProducts();

        IOrderRepository CartOnly();

        IOrderRepository BelongingTo(int userID);

        IOrderRepository DirectedTo(int userID);
    }
}
