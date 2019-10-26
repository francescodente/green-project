using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class UserBusinessCustomer
    {
        public int UserId { get; set; }

        public virtual UserBusiness User { get; set; }
    }
}
