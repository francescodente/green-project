using AutoMapper;
using FruitRacers.Backend.Core.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public abstract class AbstractService
    {
        protected IRequestSession Request { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected IDataSession Data => this.Request.Data;
        protected IUserSession RequestingUser => this.Request.User;

        public AbstractService(IRequestSession request, IMapper mapper)
        {
            this.Request = request;
            this.Mapper = mapper;
        }
    }
}
