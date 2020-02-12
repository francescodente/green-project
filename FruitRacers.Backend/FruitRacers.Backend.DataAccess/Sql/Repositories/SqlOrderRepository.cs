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
            : base(context, q => q
                .Include(o => o.Address)
                .Include(o => o.TimeSlot))
        {
        }

        private SqlOrderRepository(FruitracersContext context, Func<IQueryable<Order>, IQueryable<Order>> initialModifier)
            : base(context, initialModifier)
        {
        }

        private IOrderRepository WrapRepository(Func<IQueryable<Order>, IQueryable<Order>> modifier)
        {
            return new SqlOrderRepository(this.Context, this.WrapQuery(modifier));
        }

        public IOrderRepository AfterDate(DateTime date)
        {
            return this.WrapRepository(q => q.Where(o => o.DeliveryDate >= date));
        }

        public IOrderRepository BeforeDate(DateTime date)
        {
            return this.WrapRepository(q => q.Where(o => o.DeliveryDate <= date));
        }

        public IOrderRepository BelongingTo(int userId)
        {
            return this.WrapRepository(q => q.Where(o => o.UserId == userId));
        }

        public IOrderRepository IncludingSections()
        {
            return this.WrapRepository(q => q
                .Include(o => o.Sections)
                    .ThenInclude(s => s.Supplier)
                .Include(o => o.Sections)
                    .ThenInclude(o => o.Details)
                        .ThenInclude(d => d.Product)
                            .ThenInclude(p => p.Category)
                .Include(o => o.Sections)
                    .ThenInclude(o => o.Details)
                        .ThenInclude(d => d.Product)
                            .ThenInclude(p => p.Prices));
        }

        public IOrderRepository WithState(OrderState state)
        {
            return this.WrapRepository(q => q.Where(o => o.OrderState == state));
        }

        public IOrderRepository IncludingCustomerInfo()
        {
            return this.WrapRepository(q => q
                .Include(o => o.User)
                    .ThenInclude(u => u.CustomerBusiness)
                .Include(o => o.User)
                    .ThenInclude(u => u.Person));
        }
    }
}
