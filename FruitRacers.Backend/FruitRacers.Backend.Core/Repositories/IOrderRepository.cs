using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FruitRacers.Backend.Core.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IOrderRepository IncludingSections();

        IOrderRepository IncludingCustomerInfo();

        IOrderRepository AfterDate(DateTime date);

        IOrderRepository BeforeDate(DateTime date);

        IOrderRepository WithState(OrderState state);

        IOrderRepository WithStates(params OrderState[] states);

        IOrderRepository BelongingTo(int userId);
        
        IOrderRepository DirectedTo(int supplierId);

        IOrderRepository OrderBy<T>(Expression<Func<Order, T>> property);
    }
}
