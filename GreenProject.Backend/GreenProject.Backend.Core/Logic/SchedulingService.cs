using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class SchedulingService : AbstractService, ISchedulingService
    {
        private readonly IOrderScheduler scheduler;

        public SchedulingService(IRequestSession request, IOrderScheduler scheduler)
            : base(request)
        {
            this.scheduler = scheduler;
        }

        public async Task<DateTime> FindNextAvailableDate(int userId, int addressId)
        {
            Address address = await this.Data
                .Addresses
                .Include(a => a.Zone)
                    .ThenInclude(z => z.Availabilities)
                        .ThenInclude(a => a.Availability)
                .SingleOptionalAsync(a => a.AddressId == addressId)
                .Map(a => a.OrElseThrow(() => NotFoundException.AddressWithId(addressId)));

            ServiceUtils.RequireOwnership(address.UserId, userId);

            return await this.scheduler.FindNextAvailableDateForAddress(this.Data, address, this.DateTime.Today.AddDays(1));
        }
    }
}
