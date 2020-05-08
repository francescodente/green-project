using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Entities.Utils
{
    public readonly struct Money
    {
        public const int Decimals = 2;

        public decimal Value { get; }

        public Money(decimal value)
        {
            this.Value = decimal.Round(value, Decimals);
        }

        public static implicit operator decimal(Money money)
        {
            return money.Value;
        }

        public static implicit operator Money(decimal value)
        {
            return new Money(value);
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Value + b.Value);
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Value - b.Value);
        }

        public static Money operator *(Money money, decimal multiplier)
        {
            return new Money(money.Value * multiplier);
        }

        public static Money operator *(decimal multiplier, Money money)
        {
            return money * multiplier;
        }

        public static Money operator /(Money money, decimal divisor)
        {
            return money / divisor;
        }

        public override string ToString()
        {
            return this.Value.ToString("0,00");
        }

        public string ToString(IFormatProvider format)
        {
            return this.Value.ToString(format);
        }
    }
}
