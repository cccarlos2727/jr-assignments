using Google.Protobuf.WellKnownTypes;

namespace MoocApi.Controllers
{
    public class UserServiceDB
    {
        private readonly string _connectionString;

        public UserServiceDB(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
