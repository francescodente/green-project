using AutoMapper;
using FruitRacers.Backend.Core.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Impl
{
    public abstract class AbstractService
    {
        protected IDataSession Session { get; private set; }
        protected IMapper Mapper { get; private set; }

        public AbstractService(IDataSession session, IMapper mapper)
        {
            this.Session = session;
            this.Mapper = mapper;
        }
    }
}
