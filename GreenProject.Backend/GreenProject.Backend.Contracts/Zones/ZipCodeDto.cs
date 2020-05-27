using GreenProject.Backend.Entities.Utils;

namespace GreenProject.Backend.Contracts.Zones
{
    public class ZipCodeDto
    {
        public string ZipCode { get; set; }
        public Money ShippingSurcharge { get; set; }
    }
}
