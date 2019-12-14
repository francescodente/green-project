namespace FruitRacers.Backend.Core.Entities
{
    public enum RoleType
    {
        Person,
        Supplier,
        CustomerBusiness,
        DeliveryCompany,
        Administrator
    }

    public static class RoleTypeExtensions
    {
        public static Role GetFromUser(this RoleType roleType, User user)
        {
            switch (roleType)
            {
                case RoleType.Person:
                    return user.Person;
                case RoleType.Supplier:
                    return user.Supplier;
                case RoleType.CustomerBusiness:
                    return user.CustomerBusiness;
                case RoleType.DeliveryCompany:
                    return user.DeliveryCompany;
                case RoleType.Administrator:
                    return user.Administrator;
                default:
                    return null;
            }
        }
    }
}