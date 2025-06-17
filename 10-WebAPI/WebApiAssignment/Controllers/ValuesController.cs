using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("getjson")]
        public JsonResult GetJson()
        {
            return new JsonResult(new { Result = "success" });
        }
    }
}
