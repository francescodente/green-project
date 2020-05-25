using AutoMapper.QueryableExtensions;
using GreenProject.Backend.Contracts.Addresses;
using GreenProject.Backend.Core.EntitiesExtensions;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
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
            return RequireUserById(userId, q => q.IncludingAddresses());
        }

        public async Task<AddressDto.Output> AddAddress(int userId, AddressDto.Input address)
        {
            User user = await RequireUserWithAddresses(userId);

            Zone zone = await Data
                .Zones
                .SingleOptionalAsync(z => z.ZipCode == address.ZipCode)
                .Map(z => z.OrElseThrow(() => NotFoundException.ZoneWithZipCode(address.ZipCode)));

            Address addressEntity = new Address
            {
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                Zone = zone,
                Name = address.Name,
                Telephone = address.Telephone
            };

            user.AddAddress(addressEntity);

            await Data.SaveChangesAsync();

            return Mapper.Map<AddressDto.Output>(addressEntity);
        }

        public async Task DeleteAddress(int userId, int addressId)
        {
            User user = await RequireUserWithAddresses(userId);
            Address address = user
                .Addresses
                .SingleOptional(a => a.AddressId == addressId)
                .OrElseThrow(() => NotFoundException.AddressWithId(addressId));

            user.DeleteAddress(address);

            await Data.SaveChangesAsync();
        }

        public Task<AddressCollectionDto> GetAddresses(int userId)
        {
            return Data
                .ActiveUsers()
                .Where(u => u.UserId == userId)
                .ProjectTo<AddressCollectionDto>(Mapper.ConfigurationProvider)
                .SingleOptionalAsync()
                .Map(a => a.OrElseThrow(() => NotFoundException.UserWithId(userId)));
        }

        public async Task SetDefaultAddress(int userId, int addressId)
        {
            User user = await RequireUserWithAddresses(userId);
            if (!user.Addresses.Any(a => a.AddressId == addressId))
            {
                throw NotFoundException.AddressWithId(addressId);
            }
            user.DefaultAddressId = addressId;
            await Data.SaveChangesAsync();
        }
    }
}
