using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResultDto> Authenticate(CredentialsDto credentials);

        Task<AuthenticationResultDto> RenewToken(int userID);

        Task Logout(int userID);

        Task ChangePassword(int userID, PasswordChangeRequestDto request);
    }
}
