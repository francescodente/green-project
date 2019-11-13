using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Shared.Utils
{
    public interface IOptional<out T>
    {
        T Value { get; }

        bool IsPresent();

        bool IsAbsent();
    }
}
