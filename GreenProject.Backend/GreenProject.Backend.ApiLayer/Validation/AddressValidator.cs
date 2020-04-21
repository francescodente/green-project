using FluentValidation;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Errors;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public class AddressValidator : AbstractValidator<AddressInputDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue);

            RuleFor(x => x.HouseNumber)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue);

            RuleFor(x => x.Name)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue);

            RuleFor(x => x.ZipCode)
                .ZipCode().WithMessage(ErrorCodes.Common.IncorrectFormat)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue);

            RuleFor(x => x.Telephone)
                .NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue)
                .Length(8, 20).WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }
    }
}
