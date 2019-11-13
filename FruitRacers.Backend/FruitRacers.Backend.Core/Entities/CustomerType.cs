using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Entities
{
    public enum CustomerType
    {
        Business,
        Person
    }

    public static class CustomerTypeExtensions
    {
        public static string ToStringCode(this CustomerType type)
        {
            return type.ToString().Substring(0, 1);
        }
    }
}
