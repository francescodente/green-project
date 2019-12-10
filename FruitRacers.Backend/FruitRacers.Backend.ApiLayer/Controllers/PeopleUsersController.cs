using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/users/person")]
    [ApiController]
    [RequireLogin]
    public class PeopleUsersController : UsersController<PersonDto>
    {
        public PeopleUsersController(IUsersService<PersonDto> usersService)
            : base(usersService)
        {
        }
    }
}