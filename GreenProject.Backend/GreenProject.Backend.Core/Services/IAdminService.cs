using GreenProject.Backend.Contracts.Admin;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface IAdminService
    {
        Task SetUserEnabledState(int userId, EnabledStateDto enabledState);
    }
}
