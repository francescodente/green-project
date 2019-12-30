using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils
{
    public interface IHashCalculator
    {
        byte[] Hash(string password, byte[] salt);
    }
}
