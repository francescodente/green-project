using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.Entities;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils
{
    public interface IAuthenticationHandler
    {
        Task<(AuthenticationResultDto, RefreshToken)> OnUserAuthenticated(User user);

        bool CanBeRefreshed(string accessToken, RefreshToken refreshToken);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateRandomPassword();
    }
}
