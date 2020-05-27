using GreenProject.Backend.Contracts.Support;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Services
{
    public interface ISupportService
    {
        Task SendSupportEmail(SupportRequestDto request);
    }
}
