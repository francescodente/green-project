using GreenProject.Backend.Contracts.Zones;
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
        private readonly IOrderScheduler _scheduler;
        private readonly OrdersSettings _settings;

        public ZonesService(IRequestSession request, IOrderScheduler scheduler, OrdersSettings settings)
            : base(request)
        {
            _scheduler = scheduler;
            _settings = settings;
        }

        public async Task<DateTime> GetNextAvailableSchedule(string zipCode)
        {
            return await _scheduler.FindNextAvailableDate(DateTime.Today.AddDays(_settings.LockTimeSpanInDays), zipCode);
        }

        public async Task<IEnumerable<ProvinceDto>> GetSupportedZones()
        {
            IEnumerable<Zone> zones = await Data.Zones.ToArrayAsync();
            return zones
                .GroupBy(z => z.Province, (province, provinceZones) => new ProvinceDto
                {
                    ProvinceName = province,
                    Cities = provinceZones.GroupBy(x => x.City, (city, cityZones) => new CityDto
                    {
                        CityName = city,
                        ZipCodes = cityZones.Select(y => new ZipCodeDto
                        {
                            ZipCode = y.ZipCode,
                            ShippingSurcharge = y.ShippingSurcharge
                        })
                    })
                });
        }
    }
}
