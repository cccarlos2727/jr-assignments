using IMoocService;
using Microsoft.AspNetCore.Mvc;
using MoocApi.MoocFilters;
using MoocModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserServiceDB _userServiceDB;
        private readonly IVerificationCodeService _verificationCodeService;
        private readonly ILoggingService _loggingService;
        public UserController(IUserServiceDB userServiceDB, IUserService userService, IVerificationCodeService verificationCodeService, ILoggingService loggingService)
        {
            _userService = userService;
            _verificationCodeService = verificationCodeService;
            _loggingService = loggingService;
            _userServiceDB = userServiceDB;

        }


        [TypeFilter(typeof(MoocActionFilter), Arguments = new object[] { true })]
        [HttpGet()]
        public async Task<ApiResult> Get(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                _loggingService.LogWarning($"User with Id:{id} does not exist");
                return await Task.FromResult(new ApiResult { Success = false, Data = null, Message = "no users" });
            }
            else
            {
                _loggingService.LogInfo($"User with Id:{id} received successfully");
                return await Task.FromResult(new ApiResult { Success = true, Data = user, Message = "success" });
            }
        }

        [HttpPost]
        public async Task<ApiResult<User>> Add(User user)
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

                return await Task.FromResult(new ApiResult<User>
                {
                    Success = false,
                    Errors = errorList,
                });

            }

            var isSuccess = _userService.AddUser(user);
            _loggingService.LogInfo($"{user.UserName} is successfully added.");

            return await Task.FromResult(new ApiResult<User> { Success = isSuccess, Data = user, Message = isSuccess ? "success" : "false" });
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

                return await Task.FromResult(new ApiResult
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
                return await Task.FromResult(new ApiResult { Success = true, Data = user, Message = "success" });
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

        [HttpPost("AddUserDB")]
        public async Task<ApiResult<User>> AddUserDB(User user)
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
                return await Task.FromResult(new ApiResult<User>
                {
                    Success = false,
                    Errors = errorList,
                });
            }

            var isSuccess = _userServiceDB.AddUser(user);
            //Console.WriteLine($"Showing isSuccess Status: {isSuccess}");
            _loggingService.LogInfo($"{user.UserName} is successfully added to the database");

            return await Task.FromResult(new ApiResult<User>
            {
                Success = isSuccess,
                Data = user,
                Message = isSuccess ? "success" : "false"
            });
        }

        [HttpPut("UpdateUserDB/{id}")]
        public async Task<ApiResult> UpdateUserDB(int id, User user)
        {
            user.Id = id;

            #region Debug
            Console.WriteLine($"=== CONTROLLER DEBUG ===");
            Console.WriteLine($"Received ID from URL: {id}");
            Console.WriteLine($"User object ID set to: {user.Id}");
            #endregion

            if (!ModelState.IsValid)
            {
                _loggingService.LogWarning($"Input data is invalide, " +
                    $"User with {user.Id} info cant be updated in Database");
                List<string> errorList = new List<string>();
                foreach (var item in ModelState.Keys)
                {
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {
                            errorList.Add($"{item}: {error.ErrorMessage}");
                        }
                    }
                }
                return await Task.FromResult(new ApiResult
                {
                    Success = false,
                    Errors = errorList.ToArray()
                });
            }
            var isSuccess = _userServiceDB.UpdateUser(user);
            Console.WriteLine($"Status of isSuccess:{isSuccess}");
            _loggingService.LogInfo($"{user.UserName} info is successfully updated in Database");
            return await Task.FromResult(new ApiResult
            {
                Success = isSuccess,
                Data = user,
                Message = isSuccess ? "success" : "false"
            });
        }

        [HttpGet("GetAllDB")]
        public async Task<ApiResult<List<User>>> GetAllUserDB()
        {
            try
            {
                List<User> users = _userServiceDB.GetAllUsersWithDataAdapter();
                bool isSuccess = users.Count > 0;
                _loggingService.LogInfo($"SUccessful: Num of User is {users.Count}");
                return await Task.FromResult(new ApiResult<List<User>>
                {
                    Success = isSuccess,
                    Data = users,
                    Message = isSuccess? "Users retrived successfully": "No Users found"
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error retriving Users: {ex.Message}");
                return await Task.FromResult(new ApiResult<List<User>>
                {
                    Success = false,
                    Data = new List<User>(),
                    Message = "Error retrieving users",
                    Errors = new List<string> { ex.Message }
                });
            }
        }

        [HttpGet("GetUserByIdDB/{id}")]

        public async Task<ApiResult<User>> GetUserByIdDB(int id)
        {
            try
            {
                var user = _userServiceDB.GetUserById(id);
                bool isSuccess = user != null;
                return await Task.FromResult(new ApiResult<User>
                {
                    Success = isSuccess,
                    Data = user,
                    Message = $"User with id:{id} retreived successfully"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retriving Users: {ex.Message}");
                return await Task.FromResult(new ApiResult<User>
                {
                    Success = false,
                    Data = null,
                    Message = "Error retrieving users",
                    Errors = new List<string> { ex.Message }
                });
            }
        }


        [HttpDelete("DeleteUserDB/{id}")]
        public async Task<ApiResult> DeleteUserDB(int id)
        {            
            try
            {
                var isSuccess = _userServiceDB.DeleteUser(id);
                return await Task.FromResult(new ApiResult
                {
                    Success = isSuccess,
                    Data = null, 
                    Message = isSuccess ? "User deleted successfully" : "User not found or could not be deleted"
                });
            }
            catch(Exception ex)
            {
                return await Task.FromResult(new ApiResult
                {
                    Success = false,
                    Data = null,
                    Message = "Error deleting user",
                    Errors = new[] { ex.Message }
                });
            }
        }





    }
}
