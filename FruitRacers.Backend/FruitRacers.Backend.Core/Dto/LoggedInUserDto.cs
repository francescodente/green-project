namespace FruitRacers.Backend.Core.Dto
{
    public class LoggedInUserDto : UserDto
    {
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeliveryCompany { get; set; }
    }
}
