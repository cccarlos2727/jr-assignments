using API_Filter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Filter.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var errorResponse = new CommonResult
            {
                Success = false,
                Message = "An error occured when processing your request",
                Errors = $"Error: {context.Exception.Message}",
                Timestamp = DateTime.UtcNow
            };

            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
        
    }
}
