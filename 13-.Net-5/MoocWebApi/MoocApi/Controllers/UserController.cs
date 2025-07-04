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
        public async Task<ApiResult> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) { 
                _loggingService.LogWarning($"User with Id:{id} does not exist");
                return await Task.FromResult(new ApiResult { Success = false, Data = null, Message = "no users" });
            }
            else { 
                _loggingService.LogInfo($"User with Id:{id} received successfully");
                return await Task.FromResult(new ApiResult { Success = true, Data = user, Message = "success" });
            }
        }

        [HttpPost]
        public async Task<ApiResult<User, string[]>> Add(User user)
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

                return await Task.FromResult(new ApiResult<User, string[]>
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                });

            }

            var isSuccess = _userService.AddUser(user);
            _loggingService.LogInfo($"{user.UserName} is successfully added to the database");

            return await Task.FromResult(new ApiResult<User, string[]> { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" });
        }

        [HttpPut]
        public async Task<ApiResult> Update(User user)
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

                return await Task.FromResult (new ApiResult
                {
                    Success = false,
                    Errors = errorList.ToArray(),
                });

            }

            var isSuccess = _userService.UpdateUser(user);
            _loggingService.LogInfo($"{user.UserName} info is successfully updated");

            return await Task.FromResult(new ApiResult { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" });
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                _loggingService.LogWarning("User Id can not be null");
                return await Task.FromResult(new ApiResult { Success = false, Data = null, Message = "no users" });
            }                
            else
            {
                _loggingService.LogInfo($"User with id {id} is deleted from the database");
                var isSuccess = _userService.DeleteUser(id);
                return await Task.FromResult( new ApiResult { Success = true, Data = user, Message = "success" });
            }

        }

        [HttpGet("Getall")]
        public async Task<ApiResult> GetAll()
        {
            //throw new NotImplementedException("this is for the global error handling");

            return await Task.FromResult(new ApiResult { Success = true, Data = null, Message = true ? "success" : "false" });
          
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test(int id)
        {
            return await Task.FromResult(Ok(new { id }));
        }

        [HttpGet("log")]
        public async Task<List<string>> GetLogRecord()
        {
            return await Task.FromResult(_loggingService.GetLog());
        }

    }
}
