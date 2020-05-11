using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils.PasswordHashing
{
    public interface ISaltGenerator
    {
        byte[] NewSalt(int length);
    }
}
