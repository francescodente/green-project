using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Entities.Extensions;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class AddressesService : AbstractService, IAddressesService
    {
        public AddressesService(IRequestSession request)
            : base(request)
        {
            
        }

        public async Task<AddressOutputDto> AddAddress(int userId, AddressInputDto address)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());
            Address addressEntity = new Address
            {
                Description = address.Description,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };

            user.AddAddress(addressEntity);

            await this.Data.SaveChanges();
            return this.Mapper.Map<AddressOutputDto>(addressEntity);
        }

        public async Task DeleteAddress(int userId, int addressId)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());
            Address address = user
                .Addresses
                .SingleOptional(a => a.AddressId == addressId)
                .OrElseThrow(() => new AddressNotFoundException(addressId));

            user.DeleteAddress(address);

            await this.Data.SaveChanges();
        }

        public async Task<AddressCollectionDto> GetAddresses(int userId)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());

            return new AddressCollectionDto
            {
                Addresses = this.Mapper.Map<IEnumerable<AddressOutputDto>>(user.Addresses),
                DefaultAddressId = user.DefaultAddressId
            };
        }

        public async Task SetDefaultAddress(int userId, int addressId)
        {
            User user = await this.RequireUserById(userId, r => r.IncludingAddresses());
            if (!user.Addresses.Any(a => a.AddressId == addressId))
            {
                throw new UnauthorizedUserAccessException(userId);
            }
            user.DefaultAddressId = addressId;
            await this.Data.SaveChanges();
        }
    }
}
