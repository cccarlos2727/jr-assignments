using MoocModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMoocService
{
    public interface IUserServiceDB
    {
        public string GetConnectionString();
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int userId);
        public List<User> GetAllUserWithDataTable();

        public List<User> GetAllUserWithDataReader();

        public List<User> GetAllUsersWithDataAdapter();

        public User GetUserById(int id);
    }
}
