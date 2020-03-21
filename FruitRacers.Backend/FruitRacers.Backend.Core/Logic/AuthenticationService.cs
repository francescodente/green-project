using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Services;
using FruitRacers.Backend.Core.Utils;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace FruitRacers.Backend.Core.Logic
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

        private async Task<User> FindUserById(int userId)
        {
            return await this.FindUser(u => u.UserId == userId, () => UserNotFoundException.WithId(userId));
        }

        private async Task<User> FindUserByEmail(string email)
        {
            return await this.FindUser(u => u.Email == email, () => UserNotFoundException.WithEmail(email));
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

        public async Task<UserOutputDto> RegisterSupplier(SupplierRegistrationDto registration)
        {
            AddressInputDto addressInput = registration.Address;
            User user = this.CreateUserFromUserDto(registration.UserData);
            user.ShouldChangePassword = true;
            user.Supplier = new Supplier
            {
                BusinessName = registration.BusinessName,
                LegalForm = registration.LegalForm,
                Pec = registration.Pec,
                Sdi = registration.Sdi,
                VatNumber = registration.VatNumber,
                IsValid = true
            };
            user.AddAddress(new Address
            {
                Description = addressInput.Description,
                Latitude = addressInput.Latitude,
                Longitude = addressInput.Longitude
            });

            string generatedPassword = this.handler.GenerateRandomPassword();
            this.handler.AssignPassword(user, generatedPassword);

            this.Data.Users.Add(user);
            await this.Data.SaveChangesAsync();

            await this.Notifications.SupplierRegistered(user, generatedPassword);

            return this.Mapper.Map<UserOutputDto>(user);
        }

        private User CreateUserFromUserDto(UserInputDto userInput)
        {
            return new User
            {
                Email = userInput.Email,
                Telephone = userInput.Telephone,
                IsDeleted = false,
                IsEnabled = true,
                MarketingConsent = userInput.MarketingConsent,
                CookieConsent = userInput.CookieConsent
            };
        }
    }
}
