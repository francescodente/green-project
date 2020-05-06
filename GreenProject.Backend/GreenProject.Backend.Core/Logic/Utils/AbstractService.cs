using AutoMapper;
using GreenProject.Backend.Core.Exceptions;
using GreenProject.Backend.Core.Utils.Notifications;
using GreenProject.Backend.Core.Utils.Session;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public abstract class AbstractService
    {
        protected IRequestSession Request { get; private set; }

        protected IMapper Mapper => this.Request.Mapper;
        protected IDataSession Data => this.Request.Data;
        protected IDateTime DateTime => this.Request.DateTime;
        protected INotificationsService Notifications => this.Request.Notifications;

        public AbstractService(IRequestSession request)
        {
            this.Request = request;
        }

        private Task<IOptional<User>> FindUserById(int userId, QueryWrapper<User> queryWrapper = null)
        {
            return this.Data
                .ActiveUsers()
                .WrapIfPresent(queryWrapper)
                .SingleOptionalAsync(u => u.UserId == userId);
        }

        protected Task<User> RequireUserById(int userId, QueryWrapper<User> queryWrapper = null)
        {
            return this.FindUserById(userId, queryWrapper)
                .Map(u => u.OrElseThrow(() => NotFoundException.UserWithId(userId)));
        }
    }
}
