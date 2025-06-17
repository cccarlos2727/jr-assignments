using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Interface
{
    public interface IUserService
    {
        public JsonResult GetUserInfo();

        public object? GetUserById(int id);
        //public IActionResult AccessUserInfo(int id);


        
    }
}
