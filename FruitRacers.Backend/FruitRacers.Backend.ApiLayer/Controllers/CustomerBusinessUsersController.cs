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
    [Route("api/users/customerbusiness")]
    [ApiController]
    public class CustomerBusinessUsersController : UsersController<CustomerBusinessDto>
    {
        public CustomerBusinessUsersController(IUsersService<CustomerBusinessDto> usersService)
            : base(usersService)
        {
        }
    }
}