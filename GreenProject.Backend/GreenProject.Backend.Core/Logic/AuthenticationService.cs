using System;
using System.Linq;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils;
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

        public async Task<UserOutputDto> RegisterCustomer(RegistrationDto registration)
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
            this.Data.Users.Add(userEntity);
            await this.Data.SaveChangesAsync();

            await this.Notifications.AccountConfirmation(userEntity);

            return this.Mapper.Map<UserOutputDto>(userEntity);
        }

        private User CreateUserFromUserDto(UserInputDto userInput)
        {
            return new User
            {
                Email = userInput.Email,
                IsEnabled = true,
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
            AuthenticationResultDto result = await this.GenerateAuthenticationResult(user);
            await this.Data.SaveChangesAsync();
            return result;
        }

        public async Task<AuthenticationResultDto> RefreshToken(RefreshTokenRequestDto request)
        {
            IOptional<RefreshToken> refreshToken = await this.Data
                .RefreshTokens
                .SingleOptionalAsync(r => r.Token == request.RefreshToken);

            RefreshToken token = refreshToken
                .Filter(t => this.handler.CanBeRefreshed(request.Token, t))
                .OrElseThrow(() => new TokenRefreshFailedException());

            AuthenticationResultDto result = await this.Data
                .EnabledUsers()
                .IncludingRoles()
                .SingleAsync(u => u.UserId == token.UserId)
                .FlatMap(this.GenerateAuthenticationResult);

            refreshToken.IfPresent(t => t.IsUsed = true);
            await this.Data.SaveChangesAsync();

            return result;
        }

        private async Task<AuthenticationResultDto> GenerateAuthenticationResult(User user)
        {
            var (result, refreshToken) = await this.handler.OnUserAuthenticated(user);
            this.Data.RefreshTokens.Add(refreshToken);
            return result;
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

        public Task SendPasswordRecovery(PasswordRecoveryRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
