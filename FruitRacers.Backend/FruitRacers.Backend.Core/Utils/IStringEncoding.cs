using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Utils
{
    public interface IStringEncoding
    {
        string BytesToString(byte[] bytes);

        byte[] StringToBytes(string message);
    }
}
