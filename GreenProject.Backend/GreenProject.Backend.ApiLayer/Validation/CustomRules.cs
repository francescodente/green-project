using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public static class CustomRules
    {
        public static IRuleBuilderOptions<T, string> ZipCode<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Matches(@"\d{5}");
        }
    }
}
