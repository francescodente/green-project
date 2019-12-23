using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;

namespace FruitRacers.Backend.Contracts.Authentication
{
    public class RegistrationDto
    {
        public UserInputDto User { get; set; }
        public string Password { get; set; }
    }
}
