using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Contracts.Authentication;
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

        public AuthenticationService(IDataSession session, IMapper mapper, IAuthenticationHandler handler)
            : base(session, mapper)
        {
            this.handler = handler;
        }

        private async Task<User> FindUser(Expression<Func<User, bool>> predicate, Func<Exception> exceptionSupplier)
        {
            return await this.Session
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

        public async Task ChangePassword(int userId, PasswordChangeRequestDto request)
        {
            User user = await this.FindUserById(userId);
            this.EnsurePasswordIsCorrect(user, request.OldPassword);
            this.handler.AssignPassword(user, request.NewPassword);
            await this.Session.SaveChanges();
        }

        public async Task Logout(int userId)
        {
            await this.handler.OnUserLoggedOut(await this.FindUserById(userId));
        }

        public async Task<AuthenticationResultDto> RenewToken(int userId)
        {
            return await this.handler.OnUserAuthenticated(await this.FindUserById(userId));
        }

        private void EnsurePasswordIsCorrect(User user, string password)
        {
            if (!this.handler.IsPasswordCorrect(user, password))
            {
                throw new IncorrectPasswordException();
            }
        }
    }
}
