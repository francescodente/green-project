﻿using FluentValidation;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public class UserInputValidator : AbstractValidator<UserInputDto>
    {
        public UserInputValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}