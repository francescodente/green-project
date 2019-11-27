using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.ApiLayer.Session;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitRacers.Backend.ApiLayer.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    [RequireLogin(UserRole.Person, UserRole.Supplier)]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService addressesService;
        private readonly IRequestSession requestSession;

        public AddressesController(IAddressesService addressesService, IRequestSession requestSession)
        {
            this.addressesService = addressesService;
            this.requestSession = requestSession;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            return Ok(await this.addressesService.GetAddressesForUser(this.requestSession.UserId));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAddress([FromBody] AddressDto address)
        {
            int addressId = await this.addressesService.AddAddressForUser(this.requestSession.UserId, address);
            return Ok(new { AddressId = addressId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDto address)
        {
            await this.addressesService.UpdateAddressForUser(this.requestSession.UserId, address);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int addressId)
        {
            await this.addressesService.DeleteAddressForUser(this.requestSession.UserId, addressId);
            return NoContent();
        }
    }
}