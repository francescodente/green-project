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
    [Route("api/users/supplier")]
    [ApiController]
    [RequireLogin(UserRole.Supplier)]
    public class SupplierUsersController : UsersController<SupplierDto>
    {
        public SupplierUsersController(IUsersService<SupplierDto> usersService)
            : base(usersService)
        {
        }
    }
}