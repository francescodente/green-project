using AutoMapper;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Core.Utils.Time;

namespace FruitRacers.Backend.Core.Utils.Session
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
