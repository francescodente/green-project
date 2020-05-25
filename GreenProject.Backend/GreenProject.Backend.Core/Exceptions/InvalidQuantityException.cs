using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class InvalidQuantityException : DomainException
    {
        private readonly string _quantityProperty;

        public InvalidQuantityException(string quantityProperty = "quantity")
        {
            _quantityProperty = quantityProperty;
        }

        public override string MainErrorCode => throw new NotImplementedException();

        protected override IEnumerable<GlobalErrorDto> GetGlobalErrors()
        {
            yield break;
        }

        protected override IEnumerable<PropertyErrorDto> GetPropertyErrors()
        {
            yield return new PropertyErrorDto
            {
                Code = ErrorCodes.Orders.InvalidQuantity,
                Message = "The given quantity is not valid",
                Property = _quantityProperty
            };
        }
    }
}
