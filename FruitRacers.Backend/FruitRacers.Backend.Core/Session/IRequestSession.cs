using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Session
{
    public interface IRequestSession
    {
        IDataSession Data { get; }
        IUserSession User { get; }
    }
}
