using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IOrderRepository IncludingDetails();

        IOrderRepository IncludingDetailsAndProducts();

        IOrderRepository IncludingCustomerInfo();

        IOrderRepository AfterDate(DateTime date);

        IOrderRepository BeforeDate(DateTime date);

        IOrderRepository WithState(OrderState state);

        IOrderRepository BelongingTo(int userId);
    }
}
