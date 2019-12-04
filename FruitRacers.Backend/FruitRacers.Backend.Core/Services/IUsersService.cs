using FruitRacers.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IUsersService<TRole>
        where TRole : RoleDto
    {
        Task<int> Register(RegistrationDto<TRole> registration);

        Task<AccountDto<LoggedInUserDto, TRole>> GetUserData(int userID);

        Task UpdateUser(AccountDto<LoggedInUserDto, TRole> account);

        Task DeleteUser(int userID);
    }
}
