using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpPost("person")]
        public async Task<IActionResult> RegisterPerson([FromBody] RegistrationDto<PersonDto> registration)
        {
            int id = await this.registrationService.RegisterPerson(registration);
            return Ok(new { UserId = id });
        }

        [HttpPost("supplier")]
        public async Task<IActionResult> RegisterSupplier([FromBody] RegistrationDto<SupplierDto> registration)
        {
            int id = await this.registrationService.RegisterSupplier(registration);
            return Ok(new { UserId = id });
        }

        [HttpPost("customerbusiness")]
        public async Task<IActionResult> RegisterCustomerBusiness([FromBody] RegistrationDto<CustomerBusinessDto> registration)
        {
            int id = await this.registrationService.RegisterCustomerBusiness(registration);
            return Ok(new { UserId = id });
        }
    }
}