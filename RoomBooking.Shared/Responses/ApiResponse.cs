namespace RoomBooking.Shared.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; }
        public T? Data { get; }
        public string? Message { get; }
        private ApiResponse(bool success, T? data = default, string? message = null)
        {
            Success = success;
            Data = data;
            Message = message;
        }
        public static ApiResponse<T> SuccessResponse(T data, string? message = null) => new(true, data, message);
        public static ApiResponse<T> FailureResponse(string message) => new(false, default, message);

    }
}
