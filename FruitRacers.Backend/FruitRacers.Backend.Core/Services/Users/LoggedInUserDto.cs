using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Users
{
    public class LoggedInUserDto : UserDto
    {
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeliveryCompany { get; set; }
    }
}
