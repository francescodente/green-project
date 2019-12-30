using FruitRacers.Backend.Contracts.Users.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IRolesService
    {
        Task<PersonDto> AssignPersonRole(PersonDto person);

        Task<CustomerBusinessDto> AssignCustomerBusinessRole(CustomerBusinessDto customerBusiness);

        Task RemovePersonRole();

        Task RemoveCustomerBusinessRole();
    }
}
