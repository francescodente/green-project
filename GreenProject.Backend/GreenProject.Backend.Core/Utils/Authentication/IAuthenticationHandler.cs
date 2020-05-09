using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Authentication
{
    public interface IAuthenticationHandler
    {
        (AuthenticationResult, RefreshToken) OnUserAuthenticated(User user);

        IOptional<string> FindCurrentRefreshToken();

        bool CanBeRefreshed(string accessToken, RefreshToken refreshToken);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateRandomPassword();
    }
}
