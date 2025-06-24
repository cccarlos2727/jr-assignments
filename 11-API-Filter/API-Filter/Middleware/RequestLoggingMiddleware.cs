namespace API_Filter.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path;
            var time = DateTime.UtcNow;

            Console.WriteLine($"[Request] Path: {path}, Timestamp: {time}");

            await _next(context);
        }

    }
}
