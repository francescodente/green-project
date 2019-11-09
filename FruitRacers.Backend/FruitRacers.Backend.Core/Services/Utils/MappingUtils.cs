using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitRacers.Backend.Core.Services.Utils
{
    public static class MappingUtils
    {
        public static IMapper CreateDefaultMapper()
        {
            MapperConfiguration config = new MapperConfiguration(c =>
            {

            });
            return config.CreateMapper();
        }
    }
}
