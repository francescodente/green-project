using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils
{
    public interface ISaltGenerator
    {
        byte[] NewSalt(int length);
    }
}
