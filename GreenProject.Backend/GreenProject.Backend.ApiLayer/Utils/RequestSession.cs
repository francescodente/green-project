using AutoMapper;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Time;

namespace GreenProject.Backend.ApiLayer.Utils
{
    public class RequestSession : IRequestSession
    {
        public IDataSession Data { get; private set; }
        public IUserSession User { get; private set; }
        public IDateTime DateTime { get; private set; }
        public IMapper Mapper { get; private set; }
        public INotificationsService Notifications { get; private set; }

        public RequestSession(IDataSession data,
                              IUserSession user,
                              IDateTime dateTime,
                              IMapper mapper,
                              INotificationsService notifications)
        {
            Data = data;
            User = user;
            DateTime = dateTime;
            Mapper = mapper;
            Notifications = notifications;
        }
    }
}