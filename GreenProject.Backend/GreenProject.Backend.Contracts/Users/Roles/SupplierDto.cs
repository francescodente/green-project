using GreenProject.Backend.Contracts.Addresses;

namespace GreenProject.Backend.Contracts.Users.Roles
{
    public class SupplierDto : RoleDto
    {
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
        public string Description { get; set; }
        public AddressOutputDto Address { get; set; }
    }
}
