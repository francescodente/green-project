using GreenProject.Backend.Shared.Utils;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Core.Utils.Caching
{
    public interface ICacheService
    {
        Task StoreValue<T>(string key, T value, TimeSpan lifetime);

        Task<IOptional<T>> RetrieveValue<T>(string key);
    }
}
