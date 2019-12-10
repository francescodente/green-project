using FruitRacers.Backend.Contracts.Authentication;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task<AuthenticationResultDto> RenewToken(int userId);

        Task Logout(int userId);

        Task ChangePassword(int userId, PasswordChangeRequestDto request);
    }
}
