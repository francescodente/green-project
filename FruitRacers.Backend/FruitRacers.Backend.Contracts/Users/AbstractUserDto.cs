namespace FruitRacers.Backend.Contracts.Users
{
    public abstract class AbstractUserDto
    {
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
