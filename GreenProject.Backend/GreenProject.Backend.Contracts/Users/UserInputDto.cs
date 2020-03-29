using GreenProject.Backend.Contracts.Users.Roles;

namespace GreenProject.Backend.Contracts.Users
{
    public class UserInputDto
    {
        public string Email { get; set; }
        public string Telephone { get; set; }
        public bool MarketingConsent { get; set; }
    }
}
