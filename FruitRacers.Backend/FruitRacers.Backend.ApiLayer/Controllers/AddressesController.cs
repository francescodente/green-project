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
    [Route("api/addresses")]
    [ApiController]
    [RequireLogin(UserRole.Person, UserRole.Supplier)]
    public class AddressesController : AbstractController
    {
        private readonly IAddressesService addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            this.addressesService = addressesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            return Ok(await this.addressesService.GetAddressesForUser(this.UserId));
        }

        [HttpPost]
        public async Task<IActionResult> InsertAddress([FromBody] AddressDto address)
        {
            int addressId = await this.addressesService.AddAddressForUser(this.UserId, address);
            return Ok(new { AddressId = addressId });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDto address)
        {
            await this.addressesService.UpdateAddressForUser(this.UserId, address);
            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int addressId)
        {
            await this.addressesService.DeleteAddressForUser(this.UserId, addressId);
            return NoContent();
        }
    }
}