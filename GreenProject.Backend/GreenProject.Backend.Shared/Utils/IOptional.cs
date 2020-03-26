using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Shared.Utils
{
    public interface IOptional<out T>
    {
        T Value { get; }

        bool IsPresent();

        bool IsAbsent();
    }
}
