using AutoMapper;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public abstract class AbstractService
    {
        protected IRequestSession Request { get; private set; }

        protected IMapper Mapper => Request.Mapper;
        protected IDataSession Data => Request.Data;
        protected IDateTime DateTime => Request.DateTime;
        protected INotificationsService Notifications => Request.Notifications;

        public AbstractService(IRequestSession request)
        {
            Request = request;
        }

        private Task<IOptional<User>> FindUserById(int userId, QueryWrapper<User> queryWrapper = null)
        {
            return Data
                .ActiveUsers()
                .WrapIfPresent(queryWrapper)
                .SingleOptionalAsync(u => u.UserId == userId);
        }

        protected Task<User> RequireUserById(int userId, QueryWrapper<User> queryWrapper = null)
        {
            return FindUserById(userId, queryWrapper)
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithId(userId)));
        }
    }
}
