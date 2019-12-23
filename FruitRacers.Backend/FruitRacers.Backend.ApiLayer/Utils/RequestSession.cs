using FruitRacers.Backend.Core.Session;

namespace FruitRacers.Backend.ApiLayer.Utils
{
    public class RequestSession : IRequestSession
    {
        public IDataSession Data { get; private set; }
        public IUserSession User { get; private set; }

        public RequestSession(IDataSession data, IUserSession user)
        {
            this.Data = data;
            this.User = user;
        }
    }
}