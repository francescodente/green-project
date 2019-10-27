using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class UserAdministrator
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
