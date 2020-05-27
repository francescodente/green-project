using GreenProject.Backend.Core.Utils.Caching;
using GreenProject.Backend.Shared.Utils;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace GreenProject.Backend.Infrastructure.Caching
{
    public class InMemoryCache : ICacheService
    {
        private readonly IMemoryCache _cache;

        public InMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<IOptional<T>> RetrieveValue<T>(string key)
        {
            if (_cache.TryGetValue(key, out T value))
            {
                return Task.FromResult(Optional.Of(value));
            }

            return Task.FromResult(Optional.Empty<T>());
        }

        public Task StoreValue<T>(string key, T value, TimeSpan lifetime)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = lifetime,
                Size = 1
            };
            _cache.Set(key, value, options);

            return Task.CompletedTask;
        }
    }
}
