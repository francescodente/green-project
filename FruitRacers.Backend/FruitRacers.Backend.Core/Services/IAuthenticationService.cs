using FruitRacers.Backend.Contracts.Authentication;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<int> Register(RegistrationDto registration);

        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task<AuthenticationResultDto> RenewToken();

        Task ChangePassword(PasswordChangeRequestDto request);
    }
}
