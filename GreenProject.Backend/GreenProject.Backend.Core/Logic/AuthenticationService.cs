using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using GreenProject.Backend.Core.Entities.Extensions;
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

        private Task<User> FindUser(Expression<Func<User, bool>> predicate, Func<Exception> exceptionSupplier)
        {
            return this.Data
                .Users
                .IncludingRoles()
                .SingleOptionalAsync(predicate)
                .Map(u => u.OrElseThrow(exceptionSupplier));
        }

        private Task<User> FindUserById(int userId)
        {
            return this.FindUser(u => u.UserId == userId, () => NotFoundException.UserWithId(userId));
        }

        private Task<User> FindUserByEmail(string email)
        {
            return this.FindUser(u => u.Email == email, () => NotFoundException.UserWithEmail(email));
        }

        public async Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials)
        {
            User user = await this.FindUserByEmail(credentials.Email);
            this.EnsurePasswordIsCorrect(user, credentials.Password);
            return await this.handler.OnUserAuthenticated(user);
        }

        public async Task ChangePassword(PasswordChangeRequestDto request)
        {
            User user = await this.FindUserById(this.RequestingUser.UserId);
            this.EnsurePasswordIsCorrect(user, request.OldPassword);
            this.handler.AssignPassword(user, request.NewPassword);
            user.ShouldChangePassword = false;
            await this.Data.SaveChangesAsync();
        }

        public Task<AuthenticationResultDto> RenewToken()
        {
            return this.FindUserById(this.RequestingUser.UserId).FlatMap(this.handler.OnUserAuthenticated);
        }

        private void EnsurePasswordIsCorrect(User user, string password)
        {
            if (!this.handler.IsPasswordCorrect(user, password))
            {
                throw new IncorrectPasswordException();
            }
        }

        public async Task<UserOutputDto> RegisterCustomer(RegistrationDto registration)
        {
            User userEntity = this.CreateUserFromUserDto(registration.User);
            this.handler.AssignPassword(userEntity, registration.Password);
            this.Data.Users.Add(userEntity);
            await this.Data.SaveChangesAsync();

            // TODO: Send confirmation email

            return this.Mapper.Map<UserOutputDto>(userEntity);
        }

        private User CreateUserFromUserDto(UserInputDto userInput)
        {
            return new User
            {
                Email = userInput.Email,
                Telephone = userInput.Telephone,
                IsEnabled = true,
                MarketingConsent = userInput.MarketingConsent
            };
        }
    }
}
