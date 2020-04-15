using GreenProject.Backend.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!(context.Exception is DomainException domainException))
            {
                return;
            }
            context.Result = new BadRequestObjectResult(domainException.GetErrorResponse());
        }
    }
}
