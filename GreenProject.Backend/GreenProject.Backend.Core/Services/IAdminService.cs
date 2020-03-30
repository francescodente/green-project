using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IAdminService
    {
        Task SetUserEnabledState(int userId, bool enabled);
    }
}
