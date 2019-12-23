using FluentValidation;
using FruitRacers.Backend.Contracts.Users.Roles;
using System;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.BirthDate)
                .LessThan(_ => DateTime.Today);
        }
    }
}
