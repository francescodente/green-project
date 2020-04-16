using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Zones
{
    public class ProvinceDto
    {
        public string ProvinceName { get; set; }
        public IEnumerable<CityDto> Cities { get; set; }
    }
}