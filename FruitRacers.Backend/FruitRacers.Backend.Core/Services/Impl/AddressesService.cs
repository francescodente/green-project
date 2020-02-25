using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Core.Entities;
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

        private async Task<Address> RequireAddress(int addressId)
        {
            return await this.Data
                .Addresses
                .FindOne(a => a.AddressId == addressId)
                .Then(a => a.OrElseThrow(() => new AddressNotFoundException(addressId)));
        }

        private async Task<Address> RequireAddressWithOwnership(int userId, int addressId)
        {
            Address address = await this.RequireAddress(addressId);
            ServiceUtils.RequireOwnership(address.UserId, userId);
            return address;
        }

        public async Task<AddressOutputDto> AddAddress(int userId, AddressInputDto address)
        {
            Address addressEntity = new Address
            {
                UserId = userId,
                Description = address.Description,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
            await this.Data.Addresses.Insert(addressEntity);
            await this.Data.SaveChanges();
            return this.Mapper.Map<AddressOutputDto>(addressEntity);
        }

        public async Task DeleteAddress(int userId, int addressId)
        {
            Address address = await this.RequireAddressWithOwnership(userId, addressId);
            await this.Data.Addresses.Delete(address);
            await this.Data.SaveChanges();
        }

        public async Task<IEnumerable<AddressOutputDto>> GetAddresses(int userId)
        {
            return await this.Data
                .Addresses
                .AsEnumerable(a => a.UserId == userId)
                .Then(x => x.Select(this.Mapper.Map<Address, AddressOutputDto>));
        }

        public async Task<AddressOutputDto> UpdateAddress(int userId, int addressId, AddressInputDto address)
        {
            Address addressEntity = await this.RequireAddressWithOwnership(userId, addressId);

            addressEntity.Description = address.Description;
            addressEntity.Latitude = address.Latitude;
            addressEntity.Longitude = address.Longitude;

            await this.Data.SaveChanges();

            return this.Mapper.Map<AddressOutputDto>(addressEntity);
        }
    }
}
