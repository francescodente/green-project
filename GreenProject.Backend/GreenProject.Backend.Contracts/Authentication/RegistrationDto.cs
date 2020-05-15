using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Contracts.Users.Roles;

namespace GreenProject.Backend.Contracts.Authentication
{
    public class RegistrationDto
    {
        public UserDto.Input User { get; set; }
        public string Password { get; set; }
    }
}
