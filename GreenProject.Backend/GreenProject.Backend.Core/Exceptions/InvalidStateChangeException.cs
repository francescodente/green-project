using GreenProject.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class InvalidStateChangeException : DomainException
    {
        public InvalidStateChangeException(OrderState oldState, OrderState newState)
            : base($"Cannot transition from state {oldState} to {newState}")
        {
        }
    }
}
