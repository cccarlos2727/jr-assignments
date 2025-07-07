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

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddTransient<IVerificationCodeService, VerificationCodeService>();
            builder.Services.AddSingleton<ILoggingService, LoggingService>();
            builder.Services.AddScoped<UserServiceDB>();

            var app = builder.Build();

            //try
            //{
            //    var connectionString = app.Configuration.GetConnectionString("DefaultConnection");
            //    Console.WriteLine($"Connection String: {connectionString}");

            //    using var connection = new MySqlConnection(connectionString);
            //    connection.Open();
            //    Console.WriteLine("Connection Successful!");
            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Failed to Connect: {ex.Message}");
            //}

            // 添加自定义中间件
            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseRequestTiming();

            app.MapControllers();

            app.Run();
        }
    }
}
