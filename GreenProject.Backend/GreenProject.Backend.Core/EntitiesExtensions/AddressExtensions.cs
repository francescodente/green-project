using GreenProject.Backend.Entities;

namespace GreenProject.Backend.Core.EntitiesExtensions
{
    public static class AddressExtensions
    {
        public static string ToFormattedString(this Address address)
        {
            return $"{address.Street} {address.HouseNumber}, {address.ZipCode} {address.Zone.City} ({address.Zone.Province})";
        }
    }
}
