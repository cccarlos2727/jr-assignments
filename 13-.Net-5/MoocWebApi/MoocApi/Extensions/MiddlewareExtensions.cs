using Microsoft.AspNetCore.Builder;
using MoocApi.MiddleWares;

namespace MoocApi.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimingMiddleware>();
        }
    }
}
