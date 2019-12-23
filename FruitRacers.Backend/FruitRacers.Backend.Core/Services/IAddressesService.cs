using FruitRacers.Backend.Contracts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAddressesService
    {
        Task<IEnumerable<AddressOutputDto>> GetAddresses();

        Task<int> AddAddress(AddressInputDto address);

        Task UpdateAddress(int addressId, AddressInputDto address);

        Task DeleteAddress(int addressId);
    }
}
