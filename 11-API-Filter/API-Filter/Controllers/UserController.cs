using API_Filter.Extension;
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
        public IActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ExtractError();
                return BadRequest(CommonResult<string>.ErrorResponse(errors, "Validation Failed"));
            }
            //Adding UserId to each user
            user.UserId = Users.Count + 1;
            Users.Add(user);
            return Ok(CommonResult<User>.SuccessResult(user, "User Created Successfully"));
        }







        [HttpGet]
        [Route("api/User/GetUserInfo/{userId}")]
        public IActionResult GetUserInfo(int userId)
        {
            var user = Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return NotFound(CommonResult<string>.ErrorResponse("User not found", "Query Failed"));
            }

            return Ok(CommonResult<User>.SuccessResult(user, "User retrived successfully"));

        }

        [HttpPut]
        [Route("api/User/UpdateUser/{userId}")]
        public IActionResult UpdateUser(int userId, User userInfo)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ExtractError();
                return BadRequest(CommonResult<string>.ErrorResponse(errors, "User Update failed"));
            }

            var existingUser = Users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser == null)
            {
                return NotFound(CommonResult<string>.ErrorResponse("User not found", "Query Failed"));
            }

            existingUser.UserName = userInfo.UserName;
            existingUser.UserId = userInfo.UserId;
            existingUser.Email = userInfo.Email;
            existingUser.Phone = userInfo.Phone;
            existingUser.Gender = userInfo.Gender;
            existingUser.Address = userInfo.Address;
            existingUser.Password = userInfo.Password;
            return Ok(CommonResult<User>.SuccessResult(existingUser, "User Updated Successfully"));

        }

        [HttpDelete]
        [Route("api/User/DeleteUser/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var existingUser = Users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser == null)
            {
                return NotFound(CommonResult<string>.ErrorResponse("User not found", "Query Failed"));
            }

            Users.Remove(existingUser);
            return Ok(CommonResult<string>.SuccessResult(string.Empty, "User removed successfully"));

        }


    }
}
