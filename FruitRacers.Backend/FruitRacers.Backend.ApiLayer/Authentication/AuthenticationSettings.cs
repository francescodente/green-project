using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Authentication
{
    public class AuthenticationSettings
    {
        public string SecretKey { get; set; }
        public TimeSpan TokenDuration { get; set; }
    }
}
