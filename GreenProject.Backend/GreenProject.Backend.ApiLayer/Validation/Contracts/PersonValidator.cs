using FluentValidation;
using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.DataAccess.Sql.Model;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator(IDateTime dateTime)
        {
            RuleFor(x => x.Code)
                .ShouldNotBeEmpty();

            RuleFor(x => x.FirstName)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(PersonModel.FirstNameSize);

            RuleFor(x => x.LastName)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(PersonModel.LastNameSize);

            RuleFor(x => x.DateOfBirth)
                .LessThan(dateTime.Now).WithErrorCode(ErrorCodes.Common.ValueOutOfRange)
                .When(x => x.DateOfBirth.HasValue);

            RuleFor(x => x.Gender)
                .ShouldBeInEnum()
                .When(x => x.Gender.HasValue);
        }
    }
}
