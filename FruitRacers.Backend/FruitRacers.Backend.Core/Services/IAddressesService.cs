using FruitRacers.Backend.Contracts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAddressesService
    {
        Task<IEnumerable<AddressOutputDto>> GetAddresses();

        Task<AddressOutputDto> AddAddress(AddressInputDto address);

        Task<AddressOutputDto> UpdateAddress(int addressId, AddressInputDto address);

        Task DeleteAddress(int addressId);
    }
}
