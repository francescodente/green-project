using AutoMapper;
using FruitRacers.Backend.Contracts.Addresses;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class AddressesService : AbstractService, IAddressesService
    {
        public AddressesService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {
            
        }

        private async Task<Address> RequireAddress(int addressId)
        {
            return await this.Session
                .Addresses
                .FindOne(a => a.AddressId == addressId)
                .Then(a => a.OrElseThrow(() => new AddressNotFoundException(addressId)));
        }

        private async Task<Address> RequireAddressWithOwnership(int userId, int addressId)
        {
            Address address = await this.RequireAddress(addressId);
            ServiceUtils.EnsureOwnership(address.UserId, userId);
            return address;
        }

        public async Task<int> AddAddress(AddressInputDto address)
        {
            Address addressEntity = new Address
            {
                UserId = this.RequestingUser.UserId,
                Description = address.Description,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
            await this.Session.Addresses.Insert(addressEntity);
            await this.Session.SaveChanges();
            return addressEntity.AddressId;
        }

        public async Task DeleteAddress(int addressId)
        {
            Address address = await this.RequireAddressWithOwnership(this.RequestingUser.UserId, addressId);
            await this.Session.Addresses.Delete(address);
            await this.Session.SaveChanges();
        }

        public async Task<IEnumerable<AddressOutputDto>> GetAddresses()
        {
            return await this.Session
                .Addresses
                .Where(a => a.UserId == this.RequestingUser.UserId)
                .Then(x => x.Select(this.Mapper.Map<Address, AddressOutputDto>));
        }

        public async Task UpdateAddress(int addressId, AddressInputDto address)
        {
            Address addressEntity = await this.RequireAddressWithOwnership(this.RequestingUser.UserId, addressId);

            addressEntity.Description = address.Description;
            addressEntity.Latitude = address.Latitude;
            addressEntity.Longitude = address.Longitude;

            await this.Session.Addresses.Update(addressEntity);
            await this.Session.SaveChanges();
        }
    }
}
