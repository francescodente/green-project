using GreenProject.Backend.Contracts.Errors;
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

        public abstract string MainErrorCode { get; }

        public ErrorResponseDto GetErrorResponse()
        {
            return new ErrorResponseDto
            {
                PropertyErrors = GetPropertyErrors(),
                GlobalErrors = GetGlobalErrors()
            };
        }

        protected virtual IEnumerable<PropertyErrorDto> GetPropertyErrors()
        {
            yield break;
        }

        protected virtual IEnumerable<GlobalErrorDto> GetGlobalErrors()
        {
            yield return new GlobalErrorDto
            {
                Code = MainErrorCode,
                Message = Message
            };
        }
    }
}
