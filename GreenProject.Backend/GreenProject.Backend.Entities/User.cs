using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Entities
{
    public class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Orders = new HashSet<Order>();
            CartItems = new HashSet<CartItem>();
            BookedCrates = new HashSet<BookedCrate>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool MarketingConsent { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdministrator { get; set; }
        public bool IsSubscribed { get; set; }
        public bool ShouldChangePassword { get; set; }
        public int? DefaultAddressId { get; set; }

        public virtual CustomerBusiness CustomerBusiness { get; set; }
        public virtual DeliveryMan DeliveryCompany { get; set; }
        public virtual Person Person { get; set; }
        public virtual Address DefaultAddress { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<BookedCrate> BookedCrates { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
