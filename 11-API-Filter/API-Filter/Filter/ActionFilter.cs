using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace API_Filter.Filter
{
    public class ActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if(actionDescriptor != null)
            {
                StringBuilder message = new StringBuilder();
                var method = context.HttpContext.Request.Method.ToString();
                message.Append(method);
                
                var query = context.HttpContext.Request.Query;
                foreach(var parameter in query)
                {
                    message.AppendFormat($"parameter.key: {parameter.Key}, parameter.value: {parameter.Value}");
                }
                Console.WriteLine(message.ToString());                
            }
            Console.WriteLine("Action Filter exectued before");

            await next();
            Console.WriteLine("Action Filter exectued after");
        }
    }
}
