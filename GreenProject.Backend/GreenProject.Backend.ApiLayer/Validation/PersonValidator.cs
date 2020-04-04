using FluentValidation;
using GreenProject.Backend.Contracts.Users.Roles;
using System;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();
        }
    }
}
