using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlTimeSlotRepository : ReadOnlySqlRepository<TimeSlot>, ITimeSlotRepository
    {
        public SqlTimeSlotRepository(FruitracersContext context)
            : base(context, q => q.Include(s => s.TimeSlotOverrides))
        {
        }

        public void InsertOverride(TimeSlotOverride timeSlotOverride)
        {
            this.Context.TimeSlotOverrides.Add(timeSlotOverride);
        }
    }
}
