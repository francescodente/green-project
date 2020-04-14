using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Errors
{
    public static class ErrorCodes
    {
        private const string BASE = "ERR";

        public static class Common
        {
            public static readonly string Generic = $"{BASE}.GENERIC";

            public static readonly string MissingValue = $"{BASE}.MISSING_VALUE";

            public static readonly string IncorrectFormat = $"{BASE}.INCORRECT_FORMAT";

            public static readonly string ValueOutOfRange = $"{BASE}.VALUE_OUT_OF_RANGE";

            public static readonly string DuplicateField = $"{BASE}.DUPLICATE_FIELD";

            public static readonly string UnsupportedValue = $"{BASE}.UNSUPPORTED_VALUE";
        }
    }
}
