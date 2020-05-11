using FluentValidation;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.DataAccess.Sql.Model;

namespace GreenProject.Backend.ApiLayer.Validation.Contracts
{
    public class AddressValidator : AbstractValidator<AddressDto.Input>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(AddressModel.StreetSize);

            RuleFor(x => x.HouseNumber)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(AddressModel.HouseNumberSize);

            RuleFor(x => x.Name)
                .ShouldNotBeEmpty()
                .ShouldHaveMaxLength(AddressModel.NameSize);

            RuleFor(x => x.ZipCode)
                .ShouldNotBeEmpty()
                .ZipCode().WithErrorCode(ErrorCodes.Common.IncorrectFormat);

            RuleFor(x => x.Telephone)
                .ShouldNotBeEmpty()
                .ShouldHaveLengthBetween(8, AddressModel.TelephoneSize);
        }
    }
}
