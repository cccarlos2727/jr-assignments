using System.Net.NetworkInformation;

namespace API_Filter.ViewModel
{
    public class CommonResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public DateTime? Timestamp { get; set; }

        public static CommonResult<T> SuccessResult(T data, string message = "Success")
        {
            return new CommonResult<T>
            {
                Success = true,
                Message = message,
                Data = data,
                Errors = null
            };
        }

        public static CommonResult<T> ErrorResponse(List<string> errors, string message = "Error")
        {
            return new CommonResult<T>
            {
                Success = false,
                Message = message,
                Data = default,
                Errors = errors
            };
        }

        public static CommonResult<T> ErrorResponse(string errors, string message = "Error")
        {
            return ErrorResponse(new List<string> { errors }, message);
        }



    }
}
