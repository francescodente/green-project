using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Shared.Utils;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class AddressesService : AbstractService, IAddressesService
    {
        public AddressesService(IRequestSession request)
            : base(request)
        {

        }

        private Task<User> RequireUserWithAddresses(int userId)
        {
            return this.RequireUserById(userId, q => q.IncludingAddresses());
        }

        public async Task<AddressOutputDto> AddAddress(int userId, AddressInputDto address)
        {
            User user = await this.RequireUserWithAddresses(userId);

            Address addressEntity = new Address
            {
                Description = address.Description,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };

            user.AddAddress(addressEntity);

            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<AddressOutputDto>(addressEntity);
        }

        public async Task DeleteAddress(int userId, int addressId)
        {
            User user = await this.RequireUserWithAddresses(userId);
            Address address = user
                .Addresses
                .SingleOptional(a => a.AddressId == addressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(addressId));

            user.DeleteAddress(address);

            await this.Data.SaveChangesAsync();
        }

        public async Task<AddressCollectionDto> GetAddresses(int userId)
        {
            User user = await this.RequireUserWithAddresses(userId);

            return new AddressCollectionDto
            {
                Addresses = this.Mapper.Map<IEnumerable<AddressOutputDto>>(user.Addresses),
                DefaultAddressId = user.DefaultAddressId
            };
        }

        public async Task SetDefaultAddress(int userId, int addressId)
        {
            User user = await this.RequireUserWithAddresses(userId);
            if (!user.Addresses.Any(a => a.AddressId == addressId))
            {
                throw new UnauthorizedUserAccessException(userId);
            }
            user.DefaultAddressId = addressId;
            await this.Data.SaveChangesAsync();
        }
    }
}
