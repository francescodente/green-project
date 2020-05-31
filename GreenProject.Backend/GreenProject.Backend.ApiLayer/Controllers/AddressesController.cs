using GreenProject.Backend.ApiLayer.Filters;
using GreenProject.Backend.ApiLayer.Routes;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Controllers
{
    [Route(ApiRoutes.BaseRoute + "/customers/{userId}/addresses")]
    [ApiController]
    [RequireLogin]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService _addressesService;

        public AddressesController(IAddressesService addressesService)
        {
            _addressesService = addressesService;
        }

        [HttpGet]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> GetAddresses([FromRoute] int userId)
        {
            return Ok(await _addressesService.GetAddresses(userId));
        }

        [HttpPost]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> InsertAddress([FromRoute] int userId, [FromBody] AddressDto.Input address)
        {
            return Ok(await _addressesService.AddAddress(userId, address));
        }

        [HttpDelete("{addressId}")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> DeleteAddress([FromRoute] int userId, [FromRoute] int addressId)
        {
            await _addressesService.DeleteAddress(userId, addressId);
            return NoContent();
        }

        [HttpPut("default")]
        [OwnerOrAdminOnly]
        public async Task<IActionResult> SetDefaultAddress([FromRoute] int userId, [FromBody] DefaultAddressDto address)
        {
            await _addressesService.SetDefaultAddress(userId, address);
            return NoContent();
        }
    }
}