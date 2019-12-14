using AutoMapper;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class UsersService : AbstractService, IUsersService
    {
        public UsersService(IDataSession session, IMapper mapper)
            : base(session, mapper)
        {

        }

        public async Task DeleteUser(int userId)
        {
            await this.Session.Users.DeleteWhere(u => u.UserId == userId);
            await this.Session.SaveChanges();
        }

        public async Task<UserOutputDto> GetUserData(int userId)
        {
            User userEntity = await this.Session
                .Users
                .IncludingRoles()
                .FindOne(u => u.UserId == userId)
                .Then(u => u.Value);
            return this.Mapper.Map<UserOutputDto>(userEntity);
        }

        private Dictionary<RoleTypeDto, RoleDto> GetRoleDtos(User user)
        {
            Dictionary<RoleTypeDto, RoleDto> roles = new Dictionary<RoleTypeDto, RoleDto>();
            if (user.Administrator != null)
            {
                roles.Add(RoleTypeDto.Administrator, this.Mapper.Map<AdministratorDto>(user.Administrator));
            }
            if (user.DeliveryCompany != null)
            {
                roles.Add(RoleTypeDto.DeliveryCompany, this.Mapper.Map<DeliveryCompanyDto>(user.DeliveryCompany));
            }
            if (user.Person != null)
            {
                roles.Add(RoleTypeDto.Person, this.Mapper.Map<PersonDto>(user.Person));
            }
            if (user.CustomerBusiness != null)
            {
                roles.Add(RoleTypeDto.CustomerBusiness, this.Mapper.Map<CustomerBusinessDto>(user.CustomerBusiness));
            }
            if (user.Supplier != null)
            {
                roles.Add(RoleTypeDto.Supplier, this.Mapper.Map<SupplierDto>(user.Supplier));
            }
            return roles;
        }
    }
}
