using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Addresses
{
    public interface IAddressesService
    {
        Task<IEnumerable<AddressDto>> GetAddressesForUser(int userID);

        Task<int> AddAddressForUser(int userID, AddressDto address);

        Task UpdateAddressForUser(int userID, AddressDto address);

        Task DeleteAddressForUser(int userID, int addressID);
    }
}
