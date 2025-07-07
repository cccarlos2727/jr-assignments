using System.Diagnostics;

namespace MoocApi.MiddleWares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            
            _logger.LogInformation($"Request Method: {context.Request.Method}, Path: {context.Request.Path}, Duration: {stopwatch.ElapsedMilliseconds}ms");            
        }


    }
}
