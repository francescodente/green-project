using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils;
using FruitRacers.Backend.Shared.Utils;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class AuthenticationService : AbstractService, IAuthenticationService
    {
        private readonly IAuthenticationHandler handler;

        public AuthenticationService(IRequestSession request, IMapper mapper, IAuthenticationHandler handler)
            : base(request, mapper)
        {
            this.handler = handler;
        }

        private async Task<User> FindUser(Expression<Func<User, bool>> predicate, Func<Exception> exceptionSupplier)
        {
            return await this.Data
                .Users
                .IncludingRoles()
                .FindOne(predicate)
                .Then(u => u.OrElseThrow(exceptionSupplier));
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
            await this.Data.SaveChanges();
        }

        public async Task<AuthenticationResultDto> RenewToken()
        {
            return await this.handler.OnUserAuthenticated(await this.FindUserById(this.RequestingUser.UserId));
        }

        private void EnsurePasswordIsCorrect(User user, string password)
        {
            if (!this.handler.IsPasswordCorrect(user, password))
            {
                throw new IncorrectPasswordException();
            }
        }

        public async Task<UserOutputDto> Register(RegistrationDto registration)
        {
            UserInputDto userDto = registration.User;
            User userEntity = new User
            {
                Email = userDto.Email,
                Telephone = userDto.Telephone,
                IsDeleted = false,
                IsEnabled = true,
                MarketingConsent = userDto.MarketingConsent,
                CookieConsent = userDto.CookieConsent
            };
            this.handler.AssignPassword(userEntity, registration.Password);
            await this.Data.Users.Insert(userEntity);
            await this.Data.SaveChanges();
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }
    }
}
