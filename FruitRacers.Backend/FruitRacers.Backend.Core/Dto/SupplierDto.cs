namespace FruitRacers.Backend.Core.Dto
{
    public class SupplierDto : BusinessDto
    {
        public string Description { get; set; }
        public AddressDto Address { get; set; }
    }
}
