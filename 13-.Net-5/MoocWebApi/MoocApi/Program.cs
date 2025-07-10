using IMoocService;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocApi.MiddleWares;
using MoocApi.MoocFilters;
using MoocUserService;
using MoocService;
using MoocApi.Extensions;
using MySql.Data.MySqlClient;
using MoocApi.Controllers;

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

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserServiceDB, UserServiceDB>();
            builder.Services.AddTransient<IVerificationCodeService, VerificationCodeService>();
            builder.Services.AddSingleton<ILoggingService, LoggingService>();
            

            var app = builder.Build();

            // ����Զ����м��
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseRequestTiming();

            app.MapControllers();

            app.Run();
        }
    }
}
