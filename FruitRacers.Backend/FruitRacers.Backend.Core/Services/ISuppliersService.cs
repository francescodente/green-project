using FruitRacers.Backend.Contracts.Users.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierDto>> GetAllSuppliers();
    }
}
