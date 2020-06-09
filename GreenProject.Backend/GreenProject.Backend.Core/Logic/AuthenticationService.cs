using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.EntitiesExtensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Authentication;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {
        private readonly IAuthenticationHandler _handler;

        public AuthenticationService(IRequestSession request, IAuthenticationHandler handler)
            : base(request)
        {
            _handler = handler;
        }

        public async Task<UserDto.Output> RegisterCustomer(RegistrationDto registration)
        {
            // TODO: what happens if a user deletes his account and registers again with the same email?
            bool emailInUse = await Data
                .Users
                .AnyAsync(u => u.Email == registration.User.Email);

            if (emailInUse)
            {
                throw new EmailAlreadyInUseException();
            }

            User userEntity = CreateUserFromUserDto(registration.User);
            _handler.AssignPassword(userEntity, registration.Password);

            ConfirmationToken token = _handler.NewConfirmationToken();

            userEntity.Tokens.Add(token);

            Data.Users.Add(userEntity);
            await Data.SaveChangesAsync();

            Notifications
                .AccountConfirmation(userEntity, token.Token)
                .FireAndForget();

            return Mapper.Map<UserDto.Output>(userEntity);
        }

        public async Task ReactivateConfirmation(ReactivateConfirmationDto request)
        {
            var userData = await Data
                .Users
                .Where(u => u.Email == request.Email)
                .Where(u => !u.IsConfirmed)
                .Select(u => new
                {
                    User = u,
                    Tokens = u.Tokens.OfType<ConfirmationToken>().Where(t => !t.IsInvalid)
                })
                .SingleOptionalAsync()
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithEmail(request.Email)));

            userData.Tokens.ForEach(t => t.IsInvalid = true);

            ConfirmationToken newToken = _handler.NewConfirmationToken();
            userData.User.Tokens.Add(newToken);

            await Data.SaveChangesAsync();

            Notifications
                .AccountConfirmation(userData.User, newToken.Token)
                .FireAndForget();
        }

        private User CreateUserFromUserDto(UserDto.Input userInput)
        {
            return new User
            {
                Email = userInput.Email,
                MarketingConsent = userInput.MarketingConsent,
                IsEnabled = true
            };
        }

        public async Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials)
        {
            User user = await Data
                .ActiveUsers()
                .Where(u => u.IsEnabled)
                .IncludingRoles()
                .SingleOptionalAsync(u => u.Email == credentials.Email)
                .Map(u => u.OrElseThrow(() => new LoginFailedException()));

            EnsurePasswordIsCorrect(user, credentials.Password);

            if (!user.IsConfirmed)
            {
                throw new NotConfirmedException();
            }

            AuthenticationResultDto result = GenerateAuthenticationResult(user);
            await Data.SaveChangesAsync();
            return result;
        }

        public async Task<AuthenticationResultDto> RefreshToken(RefreshTokenRequestDto request)
        {
            string refreshToken = _handler
                .FindCurrentRefreshToken()
                .OrElseThrow(() => new TokenRefreshFailedException());

            IOptional<RefreshToken> optionalToken = await Data
                .RefreshTokens
                .SingleOptionalAsync(r => r.Token == refreshToken);

            RefreshToken validatedToken = optionalToken
                .Filter(IsTokenValid)
                .Filter(t => _handler.CanBeRefreshed(request.Token, t))
                .OrElseThrow(() => new TokenRefreshFailedException());

            AuthenticationResultDto result = await Data
                .EnabledUsers()
                .IncludingRoles()
                .SingleAsync(u => u.UserId == validatedToken.UserId)
                .Map(GenerateAuthenticationResult);

            validatedToken.IsUsed = true;
            await Data.SaveChangesAsync();

            return result;
        }

        private AuthenticationResultDto GenerateAuthenticationResult(User user)
        {
            (AuthenticationResult result, RefreshToken refreshToken) = _handler.OnUserAuthenticated(user);
            Data.RefreshTokens.Add(refreshToken);
            return new AuthenticationResultDto
            {
                Expiration = result.Expiration,
                Token = result.Token,
                UserId = user.UserId,
                Roles = user.GetRoleTypes()
            };
        }

        public async Task ChangePassword(int userId, PasswordChangeRequestDto request)
        {
            User user = await Data
                .ActiveUsers()
                .SingleOptionalAsync(u => u.UserId == userId)
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            EnsurePasswordIsCorrect(user, request.OldPassword);
            _handler.AssignPassword(user, request.NewPassword);
            user.ShouldChangePassword = false;
            await Data.SaveChangesAsync();
        }

        private void EnsurePasswordIsCorrect(User user, string password)
        {
            if (!_handler.IsPasswordCorrect(user, password))
            {
                throw new LoginFailedException();
            }
        }

        public Task ConfirmAccount(AccountConfirmationDto confirmation)
        {
            return ConsumeToken(Data.ConfirmationTokens, confirmation.Token, user =>
            {
                user.IsConfirmed = true;
            });
        }

        public async Task SendPasswordRecovery(PasswordRecoveryRequestDto request)
        {
            var requestingUser = await Data
                .EnabledUsers()
                .Where(u => u.Email == request.Email)
                .Select(u => new
                {
                    User = u,
                    Tokens = u.Tokens.OfType<PasswordRecoveryToken>().Where(t => !t.IsInvalid)
                })
                .SingleOptionalAsync();

            if (requestingUser.IsPresent())
            {
                requestingUser.Value.Tokens.ForEach(t => t.IsInvalid = true);

                User user = requestingUser.Value.User;
                PasswordRecoveryToken token = _handler.NewPasswordRecoveryToken();
                user.Tokens.Add(token);

                await Data.SaveChangesAsync();

                Notifications.PasswordRecovery(user, token.Token).FireAndForget();
            }
            else
            {
                Notifications.PasswordRecoveryAlt(request.Email).FireAndForget();
            }
        }

        public Task AcceptPasswordRecovery(PasswordRecoveryChangeDto request)
        {
            return ConsumeToken(Data.PasswordRecoveryTokens, request.Token, user =>
            {
                _handler.AssignPassword(user, request.NewPassword);
            });
        }

        private bool IsTokenValid(UserToken token)
        {
            return !(token.IsUsed || token.IsInvalid || token.Expiration < DateTime.Now);
        }

        private async Task ConsumeToken<T>(IQueryable<T> tokensQuery, string rawToken, Action<User> action)
            where T : UserToken
        {
            IOptional<T> token = await tokensQuery
                .Include(t => t.User)
                .SingleOptionalAsync(t => t.Token == rawToken);

            T validatedToken = token
                .Filter(IsTokenValid)
                .OrElseThrow(() => new ConfirmationFailedException());

            validatedToken.IsUsed = true;
            action(validatedToken.User);

            await Data.SaveChangesAsync();
        }
    }
}
