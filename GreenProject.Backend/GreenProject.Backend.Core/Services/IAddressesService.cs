using GreenProject.Backend.Contracts.Addresses;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IAddressesService
    {
        Task<AddressCollectionDto> GetAddresses(int userId);

        Task<AddressDto.Output> AddAddress(int userId, AddressDto.Input address);

        Task DeleteAddress(int userId, int addressId);

        Task SetDefaultAddress(int userId, DefaultAddressDto address);
    }
}
