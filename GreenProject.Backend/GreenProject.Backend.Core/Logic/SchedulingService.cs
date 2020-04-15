using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
            string zipCode = await this.Data
                .Addresses
                .Where(a => a.UserId == userId)
                .Where(a => a.AddressId == addressId)
                .Select(a => a.ZipCode)
                .SingleOptionalAsync()
                .Map(a => a.OrElseThrow(() => NotFoundException.AddressWithId(addressId)));

            return await this.scheduler.FindNextAvailableDate(this.DateTime.Today.AddDays(1), zipCode);
        }
    }
}
