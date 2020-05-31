using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<UserDto.Output> RegisterCustomer(RegistrationDto registration);

        Task ConfirmAccount(AccountConfirmationDto confirmation);

        Task ReactivateConfirmation(ReactivateConfirmationDto request);

        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task<AuthenticationResultDto> RefreshToken(RefreshTokenRequestDto request);

        Task ChangePassword(int userId, PasswordChangeRequestDto request);

        Task SendPasswordRecovery(PasswordRecoveryRequestDto request);

        Task AcceptPasswordRecovery(PasswordRecoveryChangeDto request);
    }
}
