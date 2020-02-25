using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils.Time
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
