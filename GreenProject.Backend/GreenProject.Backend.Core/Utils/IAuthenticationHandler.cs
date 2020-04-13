using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils
{
    public interface IAuthenticationHandler
    {
        Task<AuthenticationResultDto> OnUserAuthenticated(User user);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateRandomPassword();
    }
}
