using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
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
