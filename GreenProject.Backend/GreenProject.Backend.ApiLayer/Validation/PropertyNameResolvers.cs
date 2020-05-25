using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Validation
{
    public static class PropertyNameResolvers
    {
        public static string CamelCase(MemberInfo memberInfo, LambdaExpression expression)
        {
            return ToCamelCase(DefaultPropertyNameResolver(memberInfo, expression));
        }

        private static string DefaultPropertyNameResolver(MemberInfo memberInfo, LambdaExpression expression)
        {
            if (expression != null)
            {
                PropertyChain chain = PropertyChain.FromExpression(expression);
                if (chain.Count > 0) return chain.ToString();
            }

            if (memberInfo != null)
            {
                return memberInfo.Name;
            }

            return null;
        }

        private static string ToCamelCase(string s)
        {
            if (string.IsNullOrEmpty(s) || !char.IsUpper(s[0]))
            {
                return s;
            }

            char[] chars = s.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (i == 1 && !char.IsUpper(chars[i]))
                {
                    break;
                }

                bool hasNext = i + 1 < chars.Length;
                if (i > 0 && hasNext && !char.IsUpper(chars[i + 1]))
                {
                    break;
                }

                chars[i] = char.ToLower(chars[i], CultureInfo.InvariantCulture);
            }

            return new string(chars);
        }
    }
}
