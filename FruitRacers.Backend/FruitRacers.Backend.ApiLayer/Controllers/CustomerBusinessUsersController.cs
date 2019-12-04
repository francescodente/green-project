using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
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