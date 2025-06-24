using API_Filter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Filter.Filter
{
    public class ResultFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if(context.Result is ObjectResult objectResult && objectResult.Value is not CommonResult)
            {
                var wrapped = new CommonResult
                {
                    Success = true,
                    Message = "Request Successful",
                    Data = objectResult.Value,
                    Timestamp = DateTime.UtcNow
                };
                context.Result = new JsonResult(wrapped)
                {
                    StatusCode = objectResult.StatusCode
                };
            }                       
        }
    }
}
