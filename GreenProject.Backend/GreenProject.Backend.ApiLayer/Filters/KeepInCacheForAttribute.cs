using GreenProject.Backend.Core.Utils.Caching;
using GreenProject.Backend.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class KeepInCacheForAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _lifetimeInMinutes;

        public KeepInCacheForAttribute(int lifetimeInMinutes)
        {
            _lifetimeInMinutes = lifetimeInMinutes;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            CacheSettings cacheSettings = context.HttpContext.RequestServices.GetRequiredService<CacheSettings>();

            if (!cacheSettings.IsEnabled)
            {
                await next();
                return;
            }

            ICacheService cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            string key = GenerateKeyFromRequest(context.HttpContext.Request);
            IOptional<object> cacheHit = await cacheService.RetrieveValue<object>(key);

            if (cacheHit.IsPresent())
            {
                context.Result = new OkObjectResult(cacheHit.Value);
                return;
            }

            ActionExecutedContext actionResult = await next();

            if (actionResult.Result is OkObjectResult okObjectResult)
            {
                await cacheService.StoreValue(key, okObjectResult.Value, TimeSpan.FromMinutes(_lifetimeInMinutes));
            }
        }

        private string GenerateKeyFromRequest(HttpRequest request)
        {
            var sb = new StringBuilder();

            sb.Append(request.Path);

            foreach ((string key, Microsoft.Extensions.Primitives.StringValues value) in request.Query.OrderBy(x => x.Key))
            {
                sb.Append($"|{key}={value}");
            }

            return sb.ToString();
        }
    }
}
