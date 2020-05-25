using FluentValidation;
using GreenProject.Backend.Contracts.Filters;

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
