﻿namespace FruitRacers.Backend.Core.Dto
{
    public abstract class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
