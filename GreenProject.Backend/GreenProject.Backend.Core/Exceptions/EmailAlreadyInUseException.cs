using GreenProject.Backend.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class EmailAlreadyInUseException : DomainException
    {
        private readonly string emailProperty;

        public EmailAlreadyInUseException(string emailProperty = "email")
        {
            this.emailProperty = emailProperty;
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
                Property = this.emailProperty
            };
        }
    }
}
