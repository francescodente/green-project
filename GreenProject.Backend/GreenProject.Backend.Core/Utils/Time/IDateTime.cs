using System;

namespace GreenProject.Backend.Core.Utils.Time
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
