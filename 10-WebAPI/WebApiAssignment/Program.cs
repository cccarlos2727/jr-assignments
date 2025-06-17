using System.Threading.Channels;
using WebApiAssignment.Config;
using WebApiAssignment.Interface;
using WebApiAssignment.Interfaces;
using WebApiAssignment.Services;

namespace WebApiAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            #region Registration
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion


            #region Bind configuration
            var key = builder.Configuration["key"];            
            var mySettings = builder.Configuration.GetRequiredSection("MySettings").Get<MySettings>();            

            var mySettingsTrial = new MySettings();
            builder.Configuration.GetSection("MySettings").Bind(mySettingsTrial);
            Console.WriteLine($"AppName: {mySettingsTrial.AppName}, Version: {mySettingsTrial.Version}");
            #endregion

            #region Environment
            var environment = builder.Environment;           
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
