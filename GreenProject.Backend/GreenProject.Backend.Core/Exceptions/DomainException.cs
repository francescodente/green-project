using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message)
            : base(message)
        {

        }

        public DomainException()
        {

        }
    }
}
