using AutoMapper;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Exceptions;
using FruitRacers.Backend.Core.Logic.Utils;
using FruitRacers.Backend.Core.Utils.Notifications;
using FruitRacers.Backend.Core.Utils.Session;
using FruitRacers.Backend.Core.Utils.Time;
using FruitRacers.Backend.Shared.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FruitRacers.Backend.Core.Logic
{
    public abstract class AbstractService
    {
        protected IRequestSession Request { get; private set; }

        protected IMapper Mapper => this.Request.Mapper;
        protected IDataSession Data => this.Request.Data;
        protected IUserSession RequestingUser => this.Request.User;
        protected IDateTime DateTime => this.Request.DateTime;
        protected INotificationsService Notifications => this.Request.Notifications;

        public AbstractService(IRequestSession request)
        {
            this.Request = request;
        }

        protected Task<User> FindRequestingUser(Func<IQueryable<User>, IQueryable<User>> queryWrapper = null)
        {
            return this.RequireUserById(this.RequestingUser.UserId, queryWrapper);
        }

        protected Task<IOptional<User>> FindUserById(int userId, Func<IQueryable<User>, IQueryable<User>> queryWrapper = null)
        {
            IQueryable<User> users = this.Data.Users;
            users = queryWrapper == null ? users : queryWrapper(users);

            return users
                .Where(u => !u.IsDeleted)
                .SingleOptionalAsync(u => u.UserId == userId);
        }

        protected Task<User> RequireUserById(int userId, Func<IQueryable<User>, IQueryable<User>> queryWrapper = null)
        {
            return this.FindUserById(userId, queryWrapper)
                .Map(u => u.OrElseThrow(() => UserNotFoundException.WithId(userId)));
        }
    }
}
