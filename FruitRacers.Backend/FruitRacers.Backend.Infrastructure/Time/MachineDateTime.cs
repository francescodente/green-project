using FruitRacers.Backend.Core.Utils.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Infrastructure.Time
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Today;
    }
}
