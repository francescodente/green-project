using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;

namespace GreenProject.Backend.Core.Utils.Authentication
{
    public interface IAuthenticationHandler
    {
        (AuthenticationResult, RefreshToken) OnUserAuthenticated(User user);

        ConfirmationToken NewConfirmationToken();

        PasswordRecoveryToken NewPasswordRecoveryToken();

        IOptional<string> FindCurrentRefreshToken();

        bool CanBeRefreshed(string accessToken, RefreshToken refreshToken);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateRandomPassword();
    }
}
