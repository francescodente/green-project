using GreenProject.Backend.Core.Entities;
using GreenProject.Backend.Core.Utils.Session;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public interface IOrderScheduler
    {
        Task<DateTime> FindNextAvailableDate(IDataSession data, Address address, DateTime startingDate);
    }
}
