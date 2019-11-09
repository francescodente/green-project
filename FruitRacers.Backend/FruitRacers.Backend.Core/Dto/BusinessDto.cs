namespace FruitRacers.Backend.Core.Dto
{
    public class BusinessDto : AccountDto
    {
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
    }
}
