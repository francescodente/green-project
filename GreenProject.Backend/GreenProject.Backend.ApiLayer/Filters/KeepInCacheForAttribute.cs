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
        private readonly int lifetimeInMinutes;

        public KeepInCacheForAttribute(int lifetimeInMinutes)
        {
            this.lifetimeInMinutes = lifetimeInMinutes;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ICacheService cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            string key = this.GenerateKeyFromRequest(context.HttpContext.Request);
            IOptional<object> cacheHit = await cacheService.RetrieveValue<object>(key);

            if (cacheHit.IsPresent())
            {
                context.Result = new OkObjectResult(cacheHit.Value);
                return;
            }

            ActionExecutedContext actionResult = await next();

            if (actionResult.Result is OkObjectResult okObjectResult)
            {
                await cacheService.StoreValue(key, okObjectResult.Value, TimeSpan.FromMinutes(this.lifetimeInMinutes));
            }
        }

        private string GenerateKeyFromRequest(HttpRequest request)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(request.Path);

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                sb.Append($"|{key}={value}");
            }

            return sb.ToString();
        }
    }
}
