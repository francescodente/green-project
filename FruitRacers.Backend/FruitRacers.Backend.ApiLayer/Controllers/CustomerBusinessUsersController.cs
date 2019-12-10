using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/users/customerbusiness")]
    [ApiController]
    [RequireLogin(UserRole.CustomerBusiness)]
    public class CustomerBusinessUsersController : UsersController<CustomerBusinessDto>
    {
        public CustomerBusinessUsersController(IUsersService<CustomerBusinessDto> usersService)
            : base(usersService)
        {
        }
    }
}