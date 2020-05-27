using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;

namespace GreenProject.Backend.Core.Exceptions
{
    public class EmailAlreadyInUseException : DomainException
    {
        private readonly string _emailProperty;

        public EmailAlreadyInUseException(string emailProperty = "email")
        {
            _emailProperty = emailProperty;
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
                Code = ErrorCodes.Common.DuplicateField,
                Message = "The given email is already in use",
                Property = _emailProperty
            };
        }
    }
}
