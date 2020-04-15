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
                PropertyErrors = this.GetPropertyErrors(),
                GlobalErrors = this.GetGlobalErrors()
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
                Code = this.MainErrorCode,
                Message = this.Message
            };
        }
    }
}
