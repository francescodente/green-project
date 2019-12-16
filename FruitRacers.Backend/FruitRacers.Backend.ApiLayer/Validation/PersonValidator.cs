using FluentValidation;
using FruitRacers.Backend.Contracts.Users.Roles;
using System;

namespace FruitRacers.Backend.ApiLayer.Validation
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Cf)
                .Matches("[A-Z]{6}");

            RuleFor(x => x.BirthDate)
                .LessThan(_ => DateTime.Today);
        }
    }
}
