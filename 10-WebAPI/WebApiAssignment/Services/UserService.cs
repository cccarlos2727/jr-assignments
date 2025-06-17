using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Interface;

namespace WebApiAssignment.Services
{
    public class UserService: IUserService
    {
        public JsonResult GetUserInfo()
        {
            return new JsonResult(new { Name = "Alice", Age = 30 });
        }

        public object? GetUserById(int id)
        {
            if (id < 0) return null;
            return new { Name = "Bob", Age = 28 };
        }

    }
}
