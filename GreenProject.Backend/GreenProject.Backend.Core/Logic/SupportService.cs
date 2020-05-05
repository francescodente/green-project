using GreenProject.Backend.Contracts.Support;
using GreenProject.Backend.Core.Logic.Utils;
using GreenProject.Backend.Core.Services;
using GreenProject.Backend.Core.Utils.Session;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic
{
    public class SupportService : AbstractService, ISupportService
    {
        public SupportService(IRequestSession request)
            : base(request)
        {
            
        }

        public Task SendSupportEmail(SupportRequestDto request)
        {
            return this.Notifications.SupportRequested(request.SenderEmail, request.Subject, request.Body);
        }
    }
}
