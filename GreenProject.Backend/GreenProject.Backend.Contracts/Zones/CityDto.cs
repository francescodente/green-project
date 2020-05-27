using System.Collections.Generic;

namespace GreenProject.Backend.Contracts.Zones
{
    public class CityDto
    {
        public string CityName { get; set; }
        public IEnumerable<ZipCodeDto> ZipCodes { get; set; }
    }
}
