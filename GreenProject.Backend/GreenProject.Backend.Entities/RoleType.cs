namespace GreenProject.Backend.Entities
{
    public enum RoleType
    {
        Person,
        CustomerBusiness,
        DeliveryMan,
        Administrator
    }

    public static class RoleTypeExtensions
    {
        public static Role GetFromUser(this RoleType roleType, User user)
        {
            return roleType switch
            {
                RoleType.Person => user.Person,
                RoleType.CustomerBusiness => user.CustomerBusiness,
                RoleType.DeliveryMan => user.DeliveryCompany,
                _ => null,
            };
        }
    }
}