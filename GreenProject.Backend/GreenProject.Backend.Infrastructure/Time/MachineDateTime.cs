using GreenProject.Backend.Core.Utils.Time;
using System;

namespace GreenProject.Backend.Infrastructure.Time
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public DateTime Today => DateTime.Today;
    }
}
