using IMoocService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MoocApi.MoocFilters;
using MoocModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MoocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly ILoggingService _loggingService;
        public UserController(IUserService userService, IVerificationCodeService verificationCodeService, ILoggingService loggingService)
        {
            _userService = userService;
            _verificationCodeService = verificationCodeService;
            _loggingService = loggingService;
        }


        [TypeFilter(typeof(MoocActionFilter), Arguments = new object[] { true })]
        [HttpGet()]
        public ApiResult<User> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) { 
                _loggingService.LogWarning($"User with {id} does not exist");
                return new ApiResult<User> { Success = false, Data = null, Message = "no users" };
            }
            else { 
                _loggingService.LogInfo($"User with {id} got successfully");
                return new ApiResult<User> { Success = true, Data = user, Message = "success" };
            }
        }

        [HttpPost]
        public ApiResult<User> Add(User user)
        {
            if (!ModelState.IsValid)
            {
                _loggingService.LogWarning($"Input data is invalid, please update the format.");
                List<string> errorList = new List<string>();
                
                foreach (var item in ModelState.Keys)
                {
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {

                            errorList.Add(item + ":" + error.ErrorMessage);
                        }
                    }
                }

                return new ApiResult<User>
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                };

            }

            var isSuccess = _userService.AddUser(user);
            _loggingService.LogInfo($"{user.UserName} is successfully added to the database");

            return new ApiResult<User> { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" };
        }

        [HttpPut]
        public ApiResult<User> Update(User user)
        {
            if (!ModelState.IsValid)
            {
                _loggingService.LogWarning($"Input data is invalid, User with {user.Id} info cant be updated.");
                List<string> errorList = new List<string>();
                foreach (var item in ModelState.Keys)
                {
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {

                            errorList.Add(item + ":" + error.ErrorMessage);
                        }
                    }
                }

                return new ApiResult<User>
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                };

            }

            var isSuccess = _userService.UpdateUser(user);
            _loggingService.LogInfo($"{user.UserName} info is successfully updated");

            return new ApiResult<User> { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" };
        }

        [HttpDelete("{id}")]
        public ApiResult<User> Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                _loggingService.LogWarning("User Id can not be null");
                return new ApiResult<User> { Success = false, Data = null, Message = "no users" };
            }                
            else
            {
                _loggingService.LogInfo($"User with id {id} is deleted from the database");
                var isSuccess = _userService.DeleteUser(id);
                return new ApiResult<User> { Success = true, Data = user, Message = "success" };
            }

        }

        [HttpGet("Getall")]
        public ApiResult<User> GetAll()
        {
            //throw new NotImplementedException("this is for the global error handling");

            return new ApiResult<User> { Success = true, Data = null, Message = true ? "success" : "false" };
          
        }

        [HttpGet("test")]
        public IActionResult Test(int id)
        {
            return Ok(new { id });
        }

        [HttpGet("log")]
        public List<string> GetLogRecord()
        {
            return _loggingService.GetLog();
        }

    }
}
