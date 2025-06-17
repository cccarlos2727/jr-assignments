using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Interface;
using WebApiAssignment.Models;

namespace WebApiAssignment.Services
{
    public class UserService: IUserService
    {
        public JsonResult GetUserInfo()
        {
            return new JsonResult(new { Name = "Alice", Age = 30 });
        }

        public User? GetUserById(int id)
        {
            if (id < 0) return null;
            return new User{ Name = "Bob", Age = 28 };
        }

    }
}
