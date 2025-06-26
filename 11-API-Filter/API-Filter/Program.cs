//using API_Filter.Filter;
using API_Filter.Filter;
using API_Filter.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace API_Filter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMemoryCache();

            //Register filters globally
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add<ActionLoggingFilter>();
                options.Filters.Add<ExceptionFilter>();
                //options.Filters.Add<ResultFilter>();
            });

            // Turn off the default Bad Request response
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);


            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            // Register Middleware
            app.UseMiddleware<RequestLoggingMiddleware>();


            app.MapControllers();

            app.Run();
        }
    }
}
