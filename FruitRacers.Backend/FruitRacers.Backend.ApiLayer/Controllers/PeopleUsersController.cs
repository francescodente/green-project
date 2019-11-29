using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/users/person")]
    [ApiController]
    public class PeopleUsersController : UsersController<PersonDto>
    {
        public PeopleUsersController(IUsersService<PersonDto> usersService)
            : base(usersService)
        {
        }
    }
}