using GreenProject.Backend.Contracts.Users.Roles;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class RolesService : AbstractService, IRolesService
    {
        public RolesService(IRequestSession request)
            : base(request)
        {
        }

        private Task<User> RequireUser(int userId, Expression<Func<User, Role>> rolePropery)
        {
            return this.RequireUserById(userId, q => q.Include(rolePropery));
        }

        public async Task<CustomerBusinessDto> AssignCustomerBusinessRole(int userId, CustomerBusinessDto customerBusiness)
        {
            User user = await this.RequireUser(userId, u => u.CustomerBusiness);

            if (user.CustomerBusiness == null)
            {
                user.CustomerBusiness = new CustomerBusiness();
            }

            user.CustomerBusiness.BusinessName = customerBusiness.BusinessName;
            user.CustomerBusiness.LegalForm = customerBusiness.LegalForm;
            user.CustomerBusiness.Pec = customerBusiness.Pec;
            user.CustomerBusiness.Sdi = customerBusiness.Sdi;
            user.CustomerBusiness.VatNumber = customerBusiness.VatNumber;

            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<CustomerBusinessDto>(user.CustomerBusiness);
        }

        public async Task<PersonDto> AssignPersonRole(int userId, PersonDto person)
        {
            User user = await this.RequireUser(userId, u => u.Person);

            if (user.Person == null)
            {
                user.Person = new Person();
            }

            user.Person.FirstName = person.FirstName;
            user.Person.LastName = person.LastName;

            await this.Data.SaveChangesAsync();

            return this.Mapper.Map<PersonDto>(user.Person);
        }

        public async Task RemoveCustomerBusinessRole(int userId)
        {
            User user = await this.RequireUser(userId, u => u.CustomerBusiness);

            user.CustomerBusiness = null;

            await this.Data.SaveChangesAsync();
        }

        public async Task RemovePersonRole(int userId)
        {
            User user = await this.RequireUser(userId, u => u.Person);

            user.Person = null;

            await this.Data.SaveChangesAsync();
        }
    }
}
