using GreenProject.Backend.Contracts.Zones;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IZonesService
    {
        Task<DateTime> GetNextAvailableSchedule(string zipCode);

        Task<IEnumerable<ProvinceDto>> GetSupportedZones();
    }
}
