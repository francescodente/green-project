using AutoMapper;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Core.Utils.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Session
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
