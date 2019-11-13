using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Z.EntityFramework.Plus;
using System.Threading.Tasks;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.DataAccess.Sql.Repositories
{
    public class SqlTimeSlotRepository : ReadOnlySqlRepository<TimeSlot>, ITimeSlotRepository
    {
        public SqlTimeSlotRepository(FruitracersContext context)
            : base(context)
        {
        }

        public async Task<int> GetActualCapacity(int timeSlotID, DateTime date)
        {
            Task<int> defaultCapacityTask = this.AsQueryable()
                .Where(s => s.TimeSlotId == timeSlotID)
                .Select(s => s.SlotCapacity)
                .SingleAsync();
            Task<int> ordersCountTask = this.Context
                .Orders
                .Where(o => o.TimeSlotId == timeSlotID)
                .CountAsync();
            Task<int> overridesTask = this.Context
                .TimeSlotOverrides
                .Where(o => o.Date == date && o.TimeSlotId == timeSlotID)
                .SumAsync(o => o.Offset);

            return (await defaultCapacityTask) + (await overridesTask) - (await ordersCountTask);
        }

        public void InsertOverride(TimeSlotOverride timeSlotOverride)
        {
            this.Context.TimeSlotOverrides.Add(timeSlotOverride);
        }
    }
}
