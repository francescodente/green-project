using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<UserOutputDto> RegisterCustomer(RegistrationDto registration);

        Task<UserOutputDto> RegisterSupplier(SupplierRegistrationDto registration);

        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task<AuthenticationResultDto> RenewToken();

        Task ChangePassword(PasswordChangeRequestDto request);
    }
}
