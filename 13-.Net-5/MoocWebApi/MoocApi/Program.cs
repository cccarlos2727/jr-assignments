using IMoocService;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocApi.MiddleWares;
using MoocApi.MoocFilters;
using MoocUserService;
using MoocService;

namespace MoocApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                //global filter register, working for all actions
                options.Filters.Add<MoocExceptionFilter>();
                options.Filters.Add<MoocResultFilter>();
            });

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddTransient<IVerificationCodeService, VerificationCodeService>();
            builder.Services.AddSingleton<ILoggingService, LoggingService>();

            var app = builder.Build();

            // 添加自定义中间件
            app.UseMiddleware<RequestLoggingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
