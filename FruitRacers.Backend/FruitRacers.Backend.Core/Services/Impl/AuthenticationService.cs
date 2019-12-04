using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
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

        private async Task<User> FindUser(Expression<Func<User, bool>> predicate)
        {
            return await this.Session
                .Users
                .IncludingRoles()
                .FindOne(predicate)
                .Then(u => u.OrElseThrow(() => new UserNotFoundException()));
        }

        private async Task<User> FindUserById(int userId)
        {
            return await this.FindUser(u => u.UserId == userId);
        }

        private async Task<User> FindUserByEmail(string email)
        {
            return await this.FindUser(u => u.Email == email);
        }

        public async Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials)
        {
            User user = await this.FindUserByEmail(credentials.Email);
            this.EnsurePasswordIsCorrect(user, credentials.Password);
            return await this.handler.OnUserAuthenticated(user);
        }

        public async Task ChangePassword(int userID, PasswordChangeRequestDto request)
        {
            User user = await this.FindUserById(userID);
            this.EnsurePasswordIsCorrect(user, request.OldPassword);
            this.handler.AssignPassword(user, request.NewPassword);
            await this.Session.SaveChanges();
        }

        public async Task Logout(int userID)
        {
            await this.handler.OnUserLoggedOut(await this.FindUserById(userID));
        }

        public async Task<AuthenticationResultDto> RenewToken(int userID)
        {
            return await this.handler.OnUserAuthenticated(await this.FindUserById(userID));
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
