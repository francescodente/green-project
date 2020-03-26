using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.Time
{
    public interface IDateTime
    {
        DateTime Now { get; }
        DateTime Today { get; }
    }
}
