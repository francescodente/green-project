using FruitRacers.Backend.Contracts.Suppliers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierInfoDto>> GetAllSuppliers();
    }
}
