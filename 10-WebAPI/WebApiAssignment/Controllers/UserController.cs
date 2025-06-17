using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Interface;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public JsonResult GetUserInfo()
        {
            return this._userService.GetUserInfo();
        }

        [HttpGet]
        public IActionResult AccessUserInfo(int id)
        {
            var result = _userService.GetUserById(id);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }



    }
}
