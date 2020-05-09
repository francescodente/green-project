using FluentValidation;
using GreenProject.Backend.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequestDto>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.Token)
                .ShouldNotBeEmpty();
        }
    }
}
