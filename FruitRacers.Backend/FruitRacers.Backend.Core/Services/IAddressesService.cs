using FruitRacers.Backend.Contracts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAddressesService
    {
        Task<AddressCollectionDto> GetAddresses(int userId);

        Task<AddressOutputDto> AddAddress(int userId, AddressInputDto address);

        Task DeleteAddress(int userId, int addressId);

        Task SetDefaultAddress(int userId, int addressId);
    }
}
