using FruitRacers.Backend.Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services.Suppliers
{
    public interface ISuppliersService
    {
        Task<IEnumerable<SupplierDto>> GetAllSuppliers();
    }
}
