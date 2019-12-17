﻿using AutoMapper;
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
        public AddressesService(IDataSession session, IMapper mapper)
            : base(session, mapper)
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

        public async Task<int> AddAddressForUser(int userId, AddressInputDto address)
        {
            Address addressEntity = new Address
            {
                UserId = userId,
                Description = address.Description,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
            await this.Session.Addresses.Insert(addressEntity);
            await this.Session.SaveChanges();
            return addressEntity.AddressId;
        }

        public async Task DeleteAddressForUser(int userId, int addressId)
        {
            Address address = await this.RequireAddressWithOwnership(userId, addressId);
            await this.Session.Addresses.Delete(address);
            await this.Session.SaveChanges();
        }

        public async Task<IEnumerable<AddressOutputDto>> GetAddressesForUser(int userId)
        {
            return await this.Session
                .Addresses
                .Where(a => a.UserId == userId)
                .Then(x => x.Select(this.Mapper.Map<Address, AddressOutputDto>));
        }

        public async Task UpdateAddressForUser(int userId, int addressId, AddressInputDto address)
        {
            Address addressEntity = await this.RequireAddressWithOwnership(userId, addressId);

            addressEntity.Description = address.Description;
            addressEntity.Latitude = address.Latitude;
            addressEntity.Longitude = address.Longitude;

            await this.Session.Addresses.Update(addressEntity);
            await this.Session.SaveChanges();
        }
    }
}
