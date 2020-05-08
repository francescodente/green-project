using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Contracts.Errors
{
    public static class ErrorCodes
    {
        private const string Base = "Err";

        public static class Common
        {
            public static readonly string Generic = $"{Base}.Generic";

            public static readonly string MissingValue = $"{Base}.MissingValue";

            public static readonly string IncorrectFormat = $"{Base}.IncorrectFormat";

            public static readonly string ValueOutOfRange = $"{Base}.ValueOutOfRange";

            public static readonly string DuplicateField = $"{Base}.DuplicateField";

            public static readonly string UnsupportedValue = $"{Base}.UnsupportedValue";

            public static readonly string NotFound = $"{Base}.NotFound";

            public static string ResourceNotFound(string resourceName)
            {
                return $"{NotFound}.{resourceName}";
            }
        }

        public static class Auth
        {
            private static readonly string AuthBase = $"{Base}.Auth";

            public static readonly string LoginFailed = $"{AuthBase}.LoginFailed";

            public static readonly string MissingPermission = $"{AuthBase}.MissingPermission";

            public static readonly string UnauthorizedAccess = $"{AuthBase}.UnauthorizedAccess";

            public static readonly string RefreshFailed = $"{AuthBase}.RefreshFailed";
        }

        public static class Cart
        {
            private static readonly string CartBase = $"{Base}.Cart";

            public static readonly string Empty = $"{CartBase}.EmptyCart";
        }

        public static class Orders
        {
            private static readonly string OrdersBase = $"{Base}.Orders";

            public static readonly string InvalidStateTransition = $"{OrdersBase}.InvalidStateTransition";

            public static readonly string ReservedProduct = $"{OrdersBase}.ReservedProduct";

            public static readonly string OrderLocked = $"{OrdersBase}.OrderLocked";

            public static readonly string InvalidQuantity = $"{OrdersBase}.InvalidQuantity";
        }

        public static class Addresses
        {
            private static readonly string AddressesBase = $"{Base}.Addresses";

            public static readonly string DeletingDefaultAddress = $"{AddressesBase}.DeletingDefault";
        }

        public static class WeeklyOrders
        {
            private static readonly string WeeklyOrdersBase = $"{Base}.WeeklyOrders";

            public static readonly string NotSubscribed = $"{WeeklyOrdersBase}.NotSubscribed";

            public static readonly string AlreadySubscribed = $"{WeeklyOrdersBase}.AlreadySubscribed";

            public static readonly string IncompatibleProduct = $"{WeeklyOrdersBase}.IncompatibleProduct";
        }
    }
}
