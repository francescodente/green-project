namespace GreenProject.Backend.Entities
{
    public class CustomerBusiness : Role
    {
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
        public bool IsValid { get; set; }
    }
}
