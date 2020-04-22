using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<UserOutputDto> RegisterCustomer(RegistrationDto registration);

        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task ChangePassword(int userId, PasswordChangeRequestDto request);

        Task SendPasswordRecovery(PasswordRecoveryRequestDto request);
    }
}
