using FluentValidation;
using GreenProject.Backend.Contracts.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class PaginationFilterValidator : AbstractValidator<PaginationFilter>
    {
        public PaginationFilterValidator()
        {
            RuleFor(x => x.PageNumber)
                .ShouldBeGreaterThanOrEqualTo(0);

            RuleFor(x => x.PageSize)
                .ShouldBeGreaterThan(0);
        }
    }
}
