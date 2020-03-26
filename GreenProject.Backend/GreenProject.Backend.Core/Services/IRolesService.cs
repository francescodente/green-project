using GreenProject.Backend.Contracts.Users.Roles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IRolesService
    {
        Task<PersonDto> AssignPersonRole(int userId, PersonDto person);

        Task<CustomerBusinessDto> AssignCustomerBusinessRole(int userId, CustomerBusinessDto customerBusiness);

        Task RemovePersonRole(int userId);

        Task RemoveCustomerBusinessRole(int userId);
    }
}
