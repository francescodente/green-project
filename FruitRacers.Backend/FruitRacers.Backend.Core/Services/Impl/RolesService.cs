using AutoMapper;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class RolesService : AbstractService, IRolesService
    {
        public RolesService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {
        }

        private async Task<User> RequireUser(int userId)
        {
            return await this.RequireUserById(userId, r => r.IncludingRoles());
        }

        public async Task<CustomerBusinessDto> AssignCustomerBusinessRole(int userId, CustomerBusinessDto customerBusiness)
        {
            User user = await this.RequireUser(userId);

            if (user.CustomerBusiness is null)
            {
                user.CustomerBusiness = new CustomerBusiness();
            }

            user.CustomerBusiness.BusinessName = customerBusiness.BusinessName;
            user.CustomerBusiness.LegalForm = customerBusiness.LegalForm;
            user.CustomerBusiness.Pec = customerBusiness.Pec;
            user.CustomerBusiness.Sdi = customerBusiness.Sdi;
            user.CustomerBusiness.VatNumber = customerBusiness.VatNumber;

            await this.Data.SaveChanges();

            return this.Mapper.Map<CustomerBusinessDto>(user.CustomerBusiness);
        }

        public async Task<PersonDto> AssignPersonRole(int userId, PersonDto person)
        {
            User user = await this.RequireUser(userId);

            if (user.Person is null)
            {
                user.Person = new Person();
            }

            user.Person.Cf = person.Cf;
            user.Person.FirstName = person.FirstName;
            user.Person.LastName = person.LastName;
            user.Person.BirthDate = person.BirthDate;

            await this.Data.SaveChanges();

            return this.Mapper.Map<PersonDto>(user.Person);
        }

        public async Task RemoveCustomerBusinessRole(int userId)
        {
            User user = await this.RequireUser(userId);

            user.CustomerBusiness = null;

            await this.Data.SaveChanges();
        }

        public async Task RemovePersonRole(int userId)
        {
            User user = await this.RequireUser(userId);

            user.Person = null;

            await this.Data.SaveChanges();
        }
    }
}
