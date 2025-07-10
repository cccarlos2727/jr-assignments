using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoocModel;
using Mysqlx;
using System;

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
            //Console.WriteLine("*** FILTER IS RUNNING ***");
            //Console.WriteLine($"Value type: {context.Result?.GetType().Name}");
            // 在结果执行前处理
            if (context.Result is ObjectResult objectResult)
            {
                // 如果已经是我们的统一格式，则添加时间戳
                //if (objectResult.Value is ApiResult apiResult)
                //{
                //    // 确保 Errors 不为 null
                //    apiResult.Errors ??= Array.Empty<object>();

                //    // 添加时间戳
                //    apiResult.Data = new
                //    {
                //        Timestamp = DateTime.UtcNow,
                //        Content = apiResult.Data
                //    };
                //}

                //Console.WriteLine($"ObjectResult.Value type: {objectResult.Value?.GetType().Name}");
                //Console.WriteLine($"ObjectResult.Value: {objectResult.Value}");

                // Check if it's generic
                //bool isGeneric = objectResult.Value?.GetType().IsGenericType == true;
                //Console.WriteLine($"IsGenericType: {isGeneric}");

                //if (isGeneric)
                //{
                //    var genericDef = objectResult.Value.GetType().GetGenericTypeDefinition();
                //    Console.WriteLine($"GenericTypeDefinition: {genericDef.Name}");
                //    Console.WriteLine($"Is ApiResult<>?: {genericDef == typeof(ApiResult<>)}");
                //}

                if (objectResult.Value?.GetType().IsGenericType == true &&
                    objectResult.Value.GetType().GetGenericTypeDefinition() == typeof(ApiResult<>))
                {

                    Console.WriteLine("*** ENTERING IF CLAUSE ***");

                    dynamic apiResult = objectResult.Value;
                    objectResult.Value = new
                    {
                        Success = apiResult.Success,
                        Message = apiResult.Message,
                        Errors = apiResult.Errors ?? new List<string>(),
                        Data = new
                        {                            
                            Timestamp = DateTime.UtcNow,
                            Content = apiResult.Data
                        }
                    };
                }
                else
                {
                    Console.WriteLine("*** ENTERING ELSE CLAUSE ***");
                    //Console.WriteLine($"About to wrap: {objectResult.Value?.GetType().Name}");

                    bool isSuccess = objectResult.StatusCode == null ||
                                    (objectResult.StatusCode >= 200 &&
                                    objectResult.StatusCode < 300);
                    var newApiResult = new ApiResult<object>
                    {
                        Success = isSuccess,
                        Message = isSuccess ? "HTTP Request Succeeded" : "HTTP Request Failed",
                        //Data = objectResult.Value,
                        Data = new
                        {                            
                            Timestamp = DateTime.UtcNow,
                            Content = objectResult.Value
                        },
                        Errors = new List<string>()
                    };
                    objectResult.Value = newApiResult;
                    //objectResult.DeclaredType = typeof(ApiResult<object>);

                    //Console.WriteLine($"*** AFTER WRAPPING: {objectResult.Value?.GetType().Name} ***");
                    //Console.WriteLine($"*** NEW MESSAGE: {((dynamic)objectResult.Value).Message} ***");
                    
                }
                //{                   
                //    // 如果不是统一格式，转换为统一格式
                //    var newApiResult = new ApiResult
                //    {
                //        Success = true,
                //        Message = "Operation succeeded",
                //        Data = new
                //        {
                //            Timestamp = DateTime.UtcNow,
                //            Content = objectResult.Value
                //        },
                //        Errors = Array.Empty<object>()
                //    };

                //    objectResult.Value = newApiResult;
                //    objectResult.DeclaredType = typeof(ApiResult);
                //}
            }

        }
    }
}
