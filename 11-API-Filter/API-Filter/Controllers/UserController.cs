using API_Filter.Models;
using API_Filter.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Filter.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new List<User>();

        [HttpPost]
        [Route("api/User/AddUser")]
        public CommonResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                Users.Add(user);
                return new CommonResult()
                {
                    Success = true,
                    Message = "User is added to the database.",
                    Data = user,
                    Errors = null

                };
            } else
            {
                return new CommonResult()
                {
                    Success = false,
                    Message = "User can not be added to the database.",
                    Errors = "The format of the user input is incorrect"
                };
            }
        }


        [HttpGet]
        [Route("api/User/GetUserInfo/{userId}")]
        public CommonResult GetUserInfo(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if(user != null)
            {
                return new CommonResult()
                {
                    Success = true,
                    Message = $"User with id {userId} has been found.",
                    Data = user,
                    Errors = null
                };
            } else
            {
                return new CommonResult()
                {
                    Success = false,
                    Message = $"User with id {userId} can not be found.",                    
                    Errors = "Input userId is invalid."
                };
            }
        }

        [HttpPut]
        [Route("api/User/UpdateUser/{userId}")]
        public CommonResult UpdateUser(int userId, User userInfo)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if(user != null && ModelState.IsValid)
            {
                user.UserName = userInfo.UserName;
                user.UserId = userInfo.UserId;
                user.Email = userInfo.Email;
                user.Phone = userInfo.Phone;
                user.Gender = userInfo.Gender;
                user.Address = userInfo.Address;
                user.Password = userInfo.Password;
                return new CommonResult()
                {
                    Success = true,
                    Message = $"User info with Id {userInfo.UserId} has been updated.",
                    Data = userInfo,
                    Errors = null
                };
            } else
            {
                return new CommonResult()
                {
                    Success = false,
                    Message = $"User id {userId} can not be updated.",
                    Errors = "Input userId or user info is invalid."
                };
            }
        }

        [HttpDelete]
        [Route("api/User/DeleteUser/{userId}")]
        public CommonResult DeleteUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if(user != null)
            {
                Users.Remove(user);
                return new CommonResult()
                {
                    Success = true,
                    Message = $"User with id {user.UserId} has been removed",
                    Errors = null
                };
            } else
            {
                return new CommonResult()
                {
                    Success = false,
                    Message = $"User id {userId} can not be removed",
                    Errors = $"User id {userId} can not be found."
                };
            }
        }


    }
}
