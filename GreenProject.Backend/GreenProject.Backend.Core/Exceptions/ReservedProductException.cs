using GreenProject.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenProject.Backend.Core.Exceptions
{
    public class ReservedProductException : DomainException
    {
        public ReservedProductException(int productId, CustomerType customerType)
            : base(string.Format("Unable to purchase product with id {0} because it is forbidden to {1}",
                productId,
                GetCustomerTypeString(customerType)))
        {

        }

        private static string GetCustomerTypeString(CustomerType customerType)
        {
            switch (customerType)
            {
                case CustomerType.Business:
                    return "businesses";
                case CustomerType.Person:
                    return "private customers";
                default:
                    return "<UNKNOWN_CUSTOMER_TYPE>";
            }
        }
    }
}
