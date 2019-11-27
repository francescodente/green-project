using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IUsersService<T> where T : AccountDto
    {
        Task<T> GetUserData(int userID);

        Task<int> Register(RegistrationDto<T> registration);

        Task UpdateUser(T account);

        Task DeleteUser(int userID);
    }
}
