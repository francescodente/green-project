using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public partial class Administrator
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
