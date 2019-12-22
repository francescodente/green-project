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

        public ITimeSlotRepository IncludingOverrides(DateTime startDate, DateTime finishDate)
        {
            this.ChainQueryModification(q => q.IncludeFilter(t => t
                .TimeSlotOverrides
                .Where(o => o.Date >= startDate && o.Date <= finishDate)));
            return this;
        }
    }
}
