using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Session
{
    public interface IRequestSession
    {
        int UserId { get; }
    }
}
