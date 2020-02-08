using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Telephone { get; set; }
        public bool CookieConsent { get; set; }
        public bool MarketingConsent { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public bool ShouldChangePassword { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual CustomerBusiness CustomerBusiness { get; set; }
        public virtual DeliveryCompany DeliveryCompany { get; set; }
        public virtual Person Person { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
