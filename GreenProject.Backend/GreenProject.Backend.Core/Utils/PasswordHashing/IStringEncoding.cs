using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Utils
{
    public interface IStringEncoding
    {
        string BytesToString(byte[] bytes);

        byte[] StringToBytes(string message);
    }
}
