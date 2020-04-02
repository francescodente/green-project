using System;
using System.Threading.Tasks;
using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BASE_ROUTE + "/customers/{userId}/addresses")]
    [ApiController]
    [RequireLogin(RoleType.Person, RoleType.CustomerBusiness)]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService addressesService;
        private readonly ISchedulingService scheduling;

        public AddressesController(IAddressesService addressesService, ISchedulingService scheduling)
        {
            this.addressesService = addressesService;
            this.scheduling = scheduling;
        }

        [HttpGet]
        [OwnerOnly]
        public async Task<IActionResult> GetAddresses([FromRoute] int userId)
        {
            return Ok(await this.addressesService.GetAddresses(userId));
        }

        [HttpPost]
        [OwnerOnly]
        public async Task<IActionResult> InsertAddress([FromRoute] int userId, [FromBody] AddressInputDto address)
        {
            return Ok(await this.addressesService.AddAddress(userId, address));
        }

        [HttpDelete("{addressId}")]
        [OwnerOnly]
        public async Task<IActionResult> DeleteAddress([FromRoute] int userId, [FromRoute] int addressId)
        {
            await this.addressesService.DeleteAddress(userId, addressId);
            return NoContent();
        }

        [HttpPut("default")]
        [OwnerOnly]
        public async Task<IActionResult> SetDefaultAddress([FromRoute] int userId, [FromBody] int addressId)
        {
            await this.addressesService.SetDefaultAddress(userId, addressId);
            return NoContent();
        }

        [HttpGet("{addressId}/availability")]
        [OwnerOnly]
        public async Task<IActionResult> GetNextAvailableDate([FromRoute] int userId, [FromRoute] int addressId)
        {
            DateTime date = await this.scheduling.FindNextAvailableDate(userId, addressId);
            return Ok(new { Date = date });
        }
    }
}