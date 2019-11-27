namespace FruitRacers.Backend.Core.Dto
{
    public abstract class BusinessDto : AccountDto
    {
        public AddressDto address { get; set; }
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
    }
}
