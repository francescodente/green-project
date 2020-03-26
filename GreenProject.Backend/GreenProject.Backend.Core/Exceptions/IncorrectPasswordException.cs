using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class IncorrectPasswordException : DomainException
    {
        public IncorrectPasswordException()
            : base("The given password is incorrect")
        {

        }
    }
}
