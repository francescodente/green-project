﻿using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.Contracts.Users
{
    public class UserInputDto
    {
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
