namespace API_Filter.ViewModel
{
    public class CommonResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public string? Errors { get; set; }

        public DateTime? Timestamp { get; set; }

    }
}
