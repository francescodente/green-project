using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using System;
using System.Linq;
using Z.EntityFramework.Plus;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlTimeSlotRepository : ReadOnlySqlRepository<TimeSlot>, ITimeSlotRepository
    {
        public SqlTimeSlotRepository(FruitracersContext context)
            : base(context)
        {
        }

        private SqlTimeSlotRepository(FruitracersContext context, Func<IQueryable<TimeSlot>, IQueryable<TimeSlot>> initialModifier)
            : base(context, initialModifier)
        {
        }

        private ITimeSlotRepository WrapRepository(Func<IQueryable<TimeSlot>, IQueryable<TimeSlot>> modifier)
        {
            return new SqlTimeSlotRepository(this.Context, this.WrapQuery(modifier));
        }

        public ITimeSlotRepository IncludingOverrides(DateTime startDate, DateTime finishDate)
        {
            return this.WrapRepository(q => q.IncludeFilter(t => t
                .TimeSlotOverrides
                .Where(o => o.Date >= startDate && o.Date <= finishDate)));
        }
    }
}
