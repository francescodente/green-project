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

            public static readonly string NotFound = $"{BASE}.NOT_FOUND";
        }

        public static class Auth
        {
            private static readonly string AuthBase = $"{BASE}.AUTH";

            public static readonly string IncorrectPassword = $"{AuthBase}.INCORRECT_PASSWORD";

            public static readonly string MissingPermission = $"{AuthBase}.MISSING_PERMISSION";

            public static readonly string UnauthorizedAccess = $"{AuthBase}.UNAUTHORIZED_ACCESS";
        }

        public static class Cart
        {
            private static readonly string CartBase = $"{BASE}.CART";

            public static readonly string Empty = $"{CartBase}.EMPTY_CART";
        }

        public static class Orders
        {
            private static readonly string OrdersBase = $"{BASE}.ORDERS";

            public static readonly string InvalidStateTransition = $"{OrdersBase}.INVALID_STATE_TRANSITION";

            public static readonly string ReservedProduct = $"{OrdersBase}.RESERVED_PRODUCT";
        }

        public static class Addresses
        {
            private static readonly string AddressesBase = $"{BASE}.ADDRESSES";

            public static readonly string DeletingDefaultAddress = $"{AddressesBase}.DELETING_DEFAULT";
        }
    }
}
