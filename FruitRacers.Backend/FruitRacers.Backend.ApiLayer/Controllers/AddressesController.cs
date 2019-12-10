using System.Threading.Tasks;
using FruitRacers.Backend.ApiLayer.Filters;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Services;
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
        public async Task<IActionResult> InsertAddress([FromBody] AddressInputDto address)
        {
            int addressId = await this.addressesService.AddAddressForUser(this.UserId, address);
            return Ok(new { AddressId = addressId });
        }

        [HttpPut("{addressId}")]
        public async Task<IActionResult> UpdateAddress([FromQuery] int addressId, [FromBody] AddressInputDto address)
        {
            await this.addressesService.UpdateAddressForUser(this.UserId, addressId, address);
            return NoContent();
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int addressId)
        {
            await this.addressesService.DeleteAddressForUser(this.UserId, addressId);
            return NoContent();
        }
    }
}