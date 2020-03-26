using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class SupplierRegistrationDto
    {
        public UserInputDto UserData { get; set; }
        public string BusinessName { get; set; }
        public string LegalForm { get; set; }
        public string Pec { get; set; }
        public string Sdi { get; set; }
        public string VatNumber { get; set; }
        public AddressInputDto Address { get; set; }
    }
}
