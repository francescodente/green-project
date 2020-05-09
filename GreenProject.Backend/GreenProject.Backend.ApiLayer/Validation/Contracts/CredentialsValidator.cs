using FluentValidation;
using GreenProject.Backend.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class CredentialsValidator : AbstractValidator<CredentialsDto>
    {
        public CredentialsValidator()
        {
            RuleFor(x => x.Email)
                .ShouldNotBeEmpty()
                .ShouldBeAnEmailAddress();

            RuleFor(x => x.Password)
                .ShouldNotBeEmpty();
        }
    }
}
