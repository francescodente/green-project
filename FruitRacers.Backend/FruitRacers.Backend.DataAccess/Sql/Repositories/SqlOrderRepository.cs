using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlOrderRepository : SqlRepository<Order>, IOrderRepository
    {
        public SqlOrderRepository(FruitracersContext context)
            : base(context, q => q.Include(o => new { o.OrderState, o.Address, o.TimeSlot }))
        {
        }

        public IOrderRepository BelongingTo(int userID)
        {
            this.ChainQueryModification(q => q.Where(o => o.UserId == userID));
            return this;
        }

        public IOrderRepository CartOnly()
        {
            this.ChainQueryModification(q => q.Where(o => o.OrderStateId == 0));
            return this;
        }

        public IOrderRepository DirectedTo(int userID)
        {
            // TODO: Select only products that belong to <userID>.
            return this;
        }

        public IOrderRepository IncludingProducts()
        {
            this.ChainQueryModification(q => q
                .Include(o => o.OrderDetails)
                    .ThenInclude(d => d.Product)
                        .ThenInclude(p => new { p.ProductCategories, p.Prices }));
            return this;
        }
    }
}
