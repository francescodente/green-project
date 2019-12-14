using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users.Roles;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IRegistrationService
    {
        Task<int> RegisterPerson(RegistrationDto<PersonDto> registration);

        Task<int> RegisterSupplier(RegistrationDto<SupplierDto> registration);

        Task<int> RegisterCustomerBusiness(RegistrationDto<CustomerBusinessDto> registration);
    }
}
