using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace API_Filter.Filter
{
    public class ActionLoggingFilter : IActionFilter
    {
        private readonly ILogger<ActionLoggingFilter> _logger;

        public ActionLoggingFilter(ILogger<ActionLoggingFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var parameters = context.ActionArguments;

            _logger.LogInformation($"Executing action: {actionName}");

            foreach(var param in parameters)
            {
                _logger.LogInformation($"Parameter: {param.Key}, Value: {param.Value}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Logging finished");
        }
    }
}
