using AutoMapper;
using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using FruitRacers.Backend.Contracts.Users.Roles;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Session;
using FruitRacers.Backend.Core.Utils;
using System;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public class RegistrationService : AbstractService, IRegistrationService
    {
        private readonly IAuthenticationHandler handler;

        public RegistrationService(IDataSession session, IMapper mapper, IAuthenticationHandler handler)
            : base(session, mapper)
        {
            this.handler = handler;
        }

        public async Task<int> RegisterCustomerBusiness(RegistrationDto<CustomerBusinessDto> registration)
        {
            return await this.RegisterGenericUser(registration, (user, role) =>
            {
                user.CustomerBusiness = new CustomerBusiness
                {
                    BusinessName = role.BusinessName,
                    LegalForm = role.LegalForm,
                    Pec = role.Pec,
                    Sdi = role.Sdi,
                    VatNumber = role.VatNumber,
                    IsValid = true
                };
            });
        }

        public async Task<int> RegisterPerson(RegistrationDto<PersonDto> registration)
        {
            return await this.RegisterGenericUser(registration, (user, role) =>
            {
                user.Person = new Person
                {
                    Cf = role.Cf,
                    BirthDate = role.BirthDate,
                    FirstName = role.FirstName,
                    LastName = role.LastName
                };
            });
        }

        public async Task<int> RegisterSupplier(RegistrationDto<SupplierDto> registration)
        {
            return await this.RegisterGenericUser(registration, (user, role) =>
            {
                user.Supplier = new Supplier
                {
                    BusinessName = role.BusinessName,
                    Description = role.Description,
                    LegalForm = role.LegalForm,
                    Pec = role.Pec,
                    Sdi = role.Sdi,
                    VatNumber = role.VatNumber,
                    IsValid = true
                };
            }, enabled: false);
        }

        private async Task<int> RegisterGenericUser<T>(RegistrationDto<T> registration, Action<User, T> roleAssignment, bool enabled = true)
            where T : RoleDto
        {
            UserInputDto<T> userDto = registration.User;
            User userEntity = new User
            {
                Email = userDto.Email,
                Telephone = userDto.Telephone,
                IsDeleted = false,
                IsEnabled = enabled,
                MarketingConsent = userDto.MarketingConsent,
                CookieConsent = userDto.CookieConsent
            };
            T role = userDto.Role;
            roleAssignment(userEntity, role);
            this.handler.AssignPassword(userEntity, registration.Password);
            await this.Session.Users.Insert(userEntity);
            await this.Session.SaveChanges();
            return userEntity.UserId;
        }
    }
}