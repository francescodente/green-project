using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils
{
    public interface IAuthenticationHandler
    {
        Task<AuthenticationResultDto> OnUserAuthenticated(User user);

        Task OnUserLoggedOut(User user);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);
    }
}
