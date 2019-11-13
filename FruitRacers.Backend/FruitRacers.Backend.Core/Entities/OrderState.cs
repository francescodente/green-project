using System;
using System.Collections.Generic;

namespace FruitRacers.Backend.Core.Entities
{
    public enum OrderState
    {
        Cart = 0,
        Confirmed = 10,
        Accepted = 20,
        Rejected = 30,
        Sent = 40,
        Delivered = 50
    }
}
