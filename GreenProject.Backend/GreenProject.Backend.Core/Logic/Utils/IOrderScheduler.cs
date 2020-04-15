using GreenProject.Backend.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Logic.Utils
{
    public interface IOrderScheduler
    {
        Task<DateTime> FindNextAvailableDate(DateTime startingDate, string zipCode);
    }
}
