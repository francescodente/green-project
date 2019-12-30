using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public enum OrderState
    {
        Cart = 0,
        Pending = 10,
        Confirmed = 20,
        Canceled = 30,
        Completed = 40
    }
}
