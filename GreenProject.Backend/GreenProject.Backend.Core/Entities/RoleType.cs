namespace GreenProject.Backend.Core.Entities
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
            return roleType switch
            {
                RoleType.Person => user.Person,
                RoleType.Supplier => user.Supplier,
                RoleType.CustomerBusiness => user.CustomerBusiness,
                RoleType.DeliveryCompany => user.DeliveryCompany,
                RoleType.Administrator => user.Administrator,
                _ => null,
            };
        }
    }
}