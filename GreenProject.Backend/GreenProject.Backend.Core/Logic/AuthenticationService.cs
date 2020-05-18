using System;
using System.Linq;
using System.Threading.Tasks;
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

namespace GreenProject.Backend.Core.Logic
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {
        private readonly IAuthenticationHandler handler;

        public AuthenticationService(IRequestSession request, IAuthenticationHandler handler)
            : base(request)
        {
            this.handler = handler;
        }

        public async Task<UserDto.Output> RegisterCustomer(RegistrationDto registration)
        {
            // TODO: what happens if a user deletes his account and registers again with the same email?
            bool emailInUse = await this.Data
                .Users
                .AnyAsync(u => u.Email == registration.User.Email);

            if (emailInUse)
            {
                throw new EmailAlreadyInUseException();
            }

            User userEntity = this.CreateUserFromUserDto(registration.User);
            this.handler.AssignPassword(userEntity, registration.Password);

            ConfirmationToken token = this.handler.NewConfirmationToken();

            userEntity.Tokens.Add(token);

            this.Data.Users.Add(userEntity);
            await this.Data.SaveChangesAsync();

            this.Notifications
                .AccountConfirmation(userEntity, token.Token)
                .FireAndForget();

            return this.Mapper.Map<UserDto.Output>(userEntity);
        }

        public async Task ReactivateConfirmation(string email)
        {
            var userData = await this.Data
                .Users
                .Where(u => u.Email == email)
                .Where(u => !u.IsConfirmed)
                .Select(u => new
                {
                    User = u,
                    Tokens = u.Tokens.OfType<ConfirmationToken>().Where(t => !t.IsInvalid)
                })
                .SingleOptionalAsync()
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithEmail(email)));

            userData.Tokens.ForEach(t => t.IsInvalid = true);

            ConfirmationToken newToken = this.handler.NewConfirmationToken();
            userData.User.Tokens.Add(newToken);

            await this.Data.SaveChangesAsync();

            this.Notifications
                .AccountConfirmation(userData.User, newToken.Token)
                .FireAndForget();
        }

        private User CreateUserFromUserDto(UserDto.Input userInput)
        {
            return new User
            {
                Email = userInput.Email,
                MarketingConsent = userInput.MarketingConsent
            };
        }

        public async Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials)
        {
            User user = await this.Data
                .EnabledUsers()
                .IncludingRoles()
                .SingleOptionalAsync(u => u.Email == credentials.Email)
                .Map(u => u.OrElseThrow(() => new LoginFailedException()));
            this.EnsurePasswordIsCorrect(user, credentials.Password);
            AuthenticationResultDto result = this.GenerateAuthenticationResult(user);
            await this.Data.SaveChangesAsync();
            return result;
        }

        public async Task<AuthenticationResultDto> RefreshToken(RefreshTokenRequestDto request)
        {
            string refreshToken = this.handler
                .FindCurrentRefreshToken()
                .OrElseThrow(() => new TokenRefreshFailedException());

            IOptional<RefreshToken> optionalToken = await this.Data
                .RefreshTokens
                .SingleOptionalAsync(r => r.Token == refreshToken);

            RefreshToken validatedToken = optionalToken
                .Filter(this.IsTokenValid)
                .Filter(t => this.handler.CanBeRefreshed(request.Token, t))
                .OrElseThrow(() => new TokenRefreshFailedException());

            AuthenticationResultDto result = await this.Data
                .EnabledUsers()
                .IncludingRoles()
                .SingleAsync(u => u.UserId == validatedToken.UserId)
                .Map(this.GenerateAuthenticationResult);

            validatedToken.IsUsed = true;
            await this.Data.SaveChangesAsync();

            return result;
        }

        private AuthenticationResultDto GenerateAuthenticationResult(User user)
        {
            var (result, refreshToken) = this.handler.OnUserAuthenticated(user);
            this.Data.RefreshTokens.Add(refreshToken);
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
            User user = await this.Data
                .ActiveUsers()
                .SingleOptionalAsync(u => u.UserId == userId)
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithId(userId)));

            this.EnsurePasswordIsCorrect(user, request.OldPassword);
            this.handler.AssignPassword(user, request.NewPassword);
            user.ShouldChangePassword = false;
            await this.Data.SaveChangesAsync();
        }

        private void EnsurePasswordIsCorrect(User user, string password)
        {
            if (!this.handler.IsPasswordCorrect(user, password))
            {
                throw new LoginFailedException();
            }
        }

        public Task ConfirmAccount(AccountConfirmationDto confirmation)
        {
            return this.ConsumeToken(this.Data.ConfirmationTokens, confirmation.Token, user =>
            {
                user.IsConfirmed = true;
            });
        }

        public async Task SendPasswordRecovery(PasswordRecoveryRequestDto request)
        {
            var requestingUser = await this.Data
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
                PasswordRecoveryToken token = this.handler.NewPasswordRecoveryToken();
                user.Tokens.Add(token);

                await this.Data.SaveChangesAsync();

                this.Notifications.PasswordRecovery(user, token.Token).FireAndForget();
            }
            else
            {
                this.Notifications.PasswordRecoveryAlt(request.Email).FireAndForget();
            }
        }

        public Task AcceptPasswordRecovery(PasswordRecoveryChangeDto request)
        {
            return this.ConsumeToken(this.Data.PasswordRecoveryTokens, request.Token, user =>
            {
                this.handler.AssignPassword(user, request.NewPassword);
            });
        }

        private bool IsTokenValid(UserToken token)
        {
            return !(token.IsUsed || token.IsInvalid || token.Expiration < this.DateTime.Now);
        }

        private async Task ConsumeToken<T>(IQueryable<T> tokensQuery, string rawToken, Action<User> action)
            where T : UserToken
        {
            IOptional<T> token = await tokensQuery
                .Include(t => t.User)
                .SingleOptionalAsync(t => t.Token == rawToken);

            T validatedToken = token
                .Filter(this.IsTokenValid)
                .Filter(t => !t.User.IsConfirmed)
                .OrElseThrow(() => new ConfirmationFailedException());

            validatedToken.IsUsed = true;
            action(validatedToken.User);

            await this.Data.SaveChangesAsync();
        }
    }
}
