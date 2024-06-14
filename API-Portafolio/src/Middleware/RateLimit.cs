using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

public class RateLimitFilter : Attribute, IAsyncActionFilter
{
    private readonly int requestLimit;

    public RateLimitFilter(int requestLimit)
    {
        this.requestLimit = requestLimit;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cache = context.HttpContext.RequestServices.GetService(typeof(IMemoryCache)) as IMemoryCache;

        string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
        string cacheKey = $"RateLimit_{ipAddress}";

        if (!cache.TryGetValue(cacheKey, out int requestCount))
        {
            requestCount = 0;
        }

        if (requestCount >= requestLimit)
        {
            context.Result = new StatusCodeResult(429);
            return;
        }

        requestCount++;
        cache.Set(cacheKey, requestCount, TimeSpan.FromMinutes(1));

        next();
    }
}