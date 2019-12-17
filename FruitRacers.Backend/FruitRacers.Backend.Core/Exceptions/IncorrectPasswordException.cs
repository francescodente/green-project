using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Exceptions
{
    public class IncorrectPasswordException : DomainException
    {
        public IncorrectPasswordException()
            : base("The given password is incorrect")
        {

        }
    }
}
