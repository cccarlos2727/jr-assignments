using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Models;

namespace WebApiAssignment.Interface
{
    public interface IUserService
    {
        public JsonResult GetUserInfo();

        public User? GetUserById(int id);              
    }
}
