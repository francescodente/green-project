using AutoMapper;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Time;

namespace GreenProject.Backend.Core.Utils.Session
{
    public interface IRequestSession
    {
        IDataSession Data { get; }
        IUserSession User { get; }
        IDateTime DateTime { get; }
        IMapper Mapper { get; }
        INotificationsService Notifications { get; }
    }
}
