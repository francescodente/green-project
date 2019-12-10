using FruitRacers.Backend.Contracts.Addresses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAddressesService
    {
        Task<IEnumerable<AddressOutputDto>> GetAddressesForUser(int userId);

        Task<int> AddAddressForUser(int userId, AddressInputDto address);

        Task UpdateAddressForUser(int userId, int addressId, AddressInputDto address);

        Task DeleteAddressForUser(int userId, int addressId);
    }
}
