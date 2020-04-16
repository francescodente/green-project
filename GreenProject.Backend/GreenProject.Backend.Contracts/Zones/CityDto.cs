using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Zones
{
    public class CityDto
    {
        public string CityName { get; set; }
        public IEnumerable<string> ZipCodes { get; set; }
    }
}
