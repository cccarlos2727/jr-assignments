using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocModel;

namespace MoocApi.MoocFilters
{
    public class MoocResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            // 在结果执行前处理
            if (context.Result is ObjectResult objectResult)
            {
                // 如果已经是我们的统一格式，则添加时间戳
                if (objectResult.Value is ApiResult<object> apiResult)
                {
                    // 确保 Errors 不为 null
                    apiResult.Errors ??= Array.Empty<object>();

                    // 添加时间戳
                    apiResult.Data = new
                    {
                        Timestamp = DateTime.UtcNow,
                        Content = apiResult.Data
                    };
                }
                else
                {
                    int statusCode = objectResult.StatusCode ?? 200;
                    bool isSuccess = statusCode < 400;
                    // 如果不是统一格式，转换为统一格式
                    var newApiResult = new ApiResult<object>
                    {
                        Success = isSuccess ? true: false,
                        Message = isSuccess? "Operation succeeded": "Operation failed",
                        Data = new
                        {
                            Timestamp = DateTime.UtcNow,
                            Content = objectResult.Value
                        },
                        Errors = Array.Empty<object>()
                    };

                    objectResult.Value = newApiResult;
                    objectResult.DeclaredType = typeof(ApiResult<object>);
                }
            }

        }
    }
}
