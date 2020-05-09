using FluentValidation;
using GreenProject.Backend.ApiLayer.Validation.Configuration;
using GreenProject.Backend.Contracts.Errors;
using GreenProject.Backend.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public static class ValidationShortcuts
    {
        public static IRuleBuilderOptions<T, TProperty> ShouldNotBeEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> property)
        {
            return property.NotEmpty().WithErrorCode(ErrorCodes.Common.MissingValue);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldBeGreaterThan<T, TProperty>(this IRuleBuilder<T, TProperty> property, TProperty value)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return property.GreaterThan(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldBeGreaterThanOrEqualTo<T, TProperty>(this IRuleBuilder<T, TProperty> property, TProperty value)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return property.GreaterThanOrEqualTo(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldBeLessThan<T, TProperty>(this IRuleBuilder<T, TProperty> property, TProperty value)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return property.LessThan(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldBeLessThanOrEqualTo<T, TProperty>(this IRuleBuilder<T, TProperty> property, TProperty value)
            where TProperty : IComparable<TProperty>, IComparable
        {
            return property.LessThanOrEqualTo(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty?> ShouldBeGreaterThan<T, TProperty>(this IRuleBuilder<T, TProperty?> property, TProperty value)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return property.GreaterThan(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty?> ShouldBeGreaterThanOrEqualTo<T, TProperty>(this IRuleBuilder<T, TProperty?> property, TProperty value)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return property.GreaterThanOrEqualTo(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty?> ShouldBeLessThan<T, TProperty>(this IRuleBuilder<T, TProperty?> property, TProperty value)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return property.LessThan(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, TProperty?> ShouldBeLessThanOrEqualTo<T, TProperty>(this IRuleBuilder<T, TProperty?> property, TProperty value)
            where TProperty : struct, IComparable<TProperty>, IComparable
        {
            return property.LessThanOrEqualTo(value).WithErrorCode(ErrorCodes.Common.ValueOutOfRange);
        }

        public static IRuleBuilderOptions<T, string> ShouldHaveMaxLength<T>(this IRuleBuilder<T, string> property, int length)
        {
            return property.MaximumLength(length).WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }

        public static IRuleBuilderOptions<T, string> ShouldHaveMinLength<T>(this IRuleBuilder<T, string> property, int length)
        {
            return property.MinimumLength(length).WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }

        public static IRuleBuilderOptions<T, string> ShouldHaveLengthBetween<T>(this IRuleBuilder<T, string> property, int min, int max)
        {
            return property.Length(min, max).WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }

        public static IRuleBuilderOptions<T, string> ShouldBeAnEmailAddress<T>(this IRuleBuilder<T, string> property)
        {
            return property.EmailAddress().WithErrorCode(ErrorCodes.Common.IncorrectFormat);
        }

        public static IRuleBuilderOptions<T, string> ShouldBeAValidPassword<T>(this IRuleBuilder<T, string> property, PasswordValidationSettings settings)
        {
            return property
                .ShouldNotBeEmpty()
                .ShouldHaveLengthBetween(settings.MinimumLength, settings.MaximumLength);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldHaveScalePrecision<T, TProperty>(this IRuleBuilder<T, TProperty> property, int scale, int precision)
        {
            return property
                .ScalePrecision(scale, precision).WithErrorCode(ErrorCodes.Common.UnsupportedValue);
        }

        public static IRuleBuilderOptions<T, TProperty> ShouldBeInEnum<T, TProperty>(this IRuleBuilder<T, TProperty> property)
        {
            return property.IsInEnum().WithErrorCode(ErrorCodes.Common.UnsupportedValue);
        }
    }
}
