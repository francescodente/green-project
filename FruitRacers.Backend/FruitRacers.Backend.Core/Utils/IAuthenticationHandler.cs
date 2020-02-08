﻿using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Core.Entities;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Utils
{
    public interface IAuthenticationHandler
    {
        Task<AuthenticationResultDto> OnUserAuthenticated(User user);

        void AssignPassword(User user, string password);

        bool IsPasswordCorrect(User user, string password);

        string GenerateRandomPassword();
    }
}
