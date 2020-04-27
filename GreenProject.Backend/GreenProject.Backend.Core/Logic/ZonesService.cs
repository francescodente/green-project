using GreenProject.Backend.Contracts.Zones;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class ZonesService : AbstractService, IZonesService
    {
        private readonly IOrderScheduler scheduler;
        private readonly OrdersSettings settings;

        public ZonesService(IRequestSession request, IOrderScheduler scheduler, OrdersSettings settings)
            : base(request)
        {
            this.scheduler = scheduler;
            this.settings = settings;
        }

        public async Task<DateTime> GetNextAvailableSchedule(string zipCode)
        {
            return await this.scheduler.FindNextAvailableDate(this.DateTime.Today.AddDays(settings.LockTimeSpanInDays), zipCode);
        }

        public async Task<IEnumerable<ProvinceDto>> GetSupportedZones()
        {
            IEnumerable<Zone> zones = await this.Data.Zones.ToArrayAsync();
            return zones
                .GroupBy(z => z.Province, (province, provinceZones) => new ProvinceDto
                {
                    ProvinceName = province,
                    Cities = provinceZones.GroupBy(x => x.City, (city, cityZones) => new CityDto
                    {
                        CityName = city,
                        ZipCodes = cityZones.Select(y => y.ZipCode)
                    })
                });
        }
    }
}
