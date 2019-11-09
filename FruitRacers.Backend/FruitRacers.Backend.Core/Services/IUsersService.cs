using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IUsersService<T> where T : class
    {
        Task<T> GetUserData(int userID, bool isLoggedIn);

        Task<int> Register(T account);

        Task UpdateUser(T account);

        Task DeleteUser(int userID);
    }
}
