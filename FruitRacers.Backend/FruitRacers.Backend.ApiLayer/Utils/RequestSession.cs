using AutoMapper;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Core.Utils.Time;

namespace FruitRacers.Backend.ApiLayer.Utils
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
            this.Data = data;
            this.User = user;
            this.DateTime = dateTime;
            this.Mapper = mapper;
            this.Notifications = notifications;
        }
    }
}