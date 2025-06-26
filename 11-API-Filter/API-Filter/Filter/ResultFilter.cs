using API_Filter.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API_Filter.Filter
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult
                && objectResult.StatusCode >= 200
                && objectResult.StatusCode < 300)
            {
                var formatted = new
                {
                    success = true,
                    message = "Request Successful",
                    data = objectResult.Value,
                    errors = default(string[]),
                    timeStame = DateTime.UtcNow
                };

                context.Result = new JsonResult(formatted)
                {
                    StatusCode = objectResult.StatusCode
                };

            }
        }
        
        public void OnResultExecuted(ResultExecutedContext context)
        {       
        }
    }
}
