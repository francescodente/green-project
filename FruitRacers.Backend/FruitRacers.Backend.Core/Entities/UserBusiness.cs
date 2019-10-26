using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class UserBusiness
    {
        public int UserId { get; set; }
        public string VatNumber { get; set; }
        public string BusinessName { get; set; }
        public string Sdi { get; set; }
        public string Pec { get; set; }
        public string LegalForm { get; set; }
        public bool IsValid { get; set; }

        public virtual User User { get; set; }
        public virtual UserBusinessCustomer UserBusinessCustomer { get; set; }
    }
}
