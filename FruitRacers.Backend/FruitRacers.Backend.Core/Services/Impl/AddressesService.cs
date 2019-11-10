using AutoMapper;
using FruitRacers.Backend.Core.Dto;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Services.Utils;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class AddressesService : AbstractService, IAddressesService
    {
        public AddressesService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {
            
        }

        private async Task<Address> RequireAddress(int addressID)
        {
            return await this.Session.Addresses.FindOne(a => a.AddressId == addressID).Then(a => a.Value);
        }

        private async Task<Address> RequireAddressWithOwnership(int userID, int addressID)
        {
            Address address = await this.RequireAddress(addressID);
            ServiceUtils.EnsureOwnership(address.UserId, userID);
            return address;
        }

        public async Task<int> AddAddressForUser(int userID, AddressDto address)
        {
            Address addressEntity = this.Mapper.Map(address, new Address { UserId = userID });
            this.Session.Addresses.Insert(addressEntity);
            await this.Session.SaveChanges();
            return addressEntity.AddressId;
        }

        public async Task DeleteAddressForUser(int userID, int addressID)
        {
            Address address = await this.RequireAddressWithOwnership(userID, addressID);
            this.Session.Addresses.Delete(address);
            await this.Session.SaveChanges();
        }

        public async Task<IEnumerable<AddressDto>> GetAddressesForUser(int userID)
        {
            return await this.Session
                .Addresses
                .Where(a => a.UserId == userID)
                .Then(x => x.Select(this.Mapper.Map<Address, AddressDto>));
        }

        public async Task UpdateAddressForUser(int userID, AddressDto address)
        {
            Address addressEntity = await this.RequireAddressWithOwnership(userID, address.AddressId);
            this.Mapper.Map(address, addressEntity);
            this.Session.Addresses.Update(addressEntity);
            await this.Session.SaveChanges();
        }
    }
}
