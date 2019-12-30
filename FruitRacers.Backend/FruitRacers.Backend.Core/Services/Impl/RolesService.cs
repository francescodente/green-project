using AutoMapper;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class RolesService : AbstractService, IRolesService
    {
        public RolesService(IRequestSession request, IMapper mapper)
            : base(request, mapper)
        {
        }

        public async Task<CustomerBusinessDto> AssignCustomerBusinessRole(CustomerBusinessDto customerBusiness)
        {
            User user = await this.FindRequestingUser(r => r.IncludingRoles());

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

        public async Task<PersonDto> AssignPersonRole(PersonDto person)
        {
            User user = await this.FindRequestingUser(r => r.IncludingRoles());

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

        public async Task RemoveCustomerBusinessRole()
        {
            User user = await this.FindRequestingUser(r => r.IncludingRoles());

            user.CustomerBusiness = null;

            await this.Data.SaveChanges();
        }

        public async Task RemovePersonRole()
        {
            User user = await this.FindRequestingUser(r => r.IncludingRoles());

            user.Person = null;

            await this.Data.SaveChanges();
        }
    }
}
