using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Services
{
    public interface IAdminService
    {
        Task SetUserEnabledState(int supplierId, bool enabled);

        Task SetProductEnabledState(int productId, bool enabled);
    }
}
