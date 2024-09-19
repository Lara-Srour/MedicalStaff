
namespace MedicalStaff.Application.Resposne
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public ApiResponse(T data, string message = null, bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public static ApiResponse<T> CreateSuccessResponse(T data, string message)
        {
            return new ApiResponse<T>(data, message);
        }

        public static ApiResponse<T> CreateErrorResponse(string message)
        {
            return new ApiResponse<T>(default, message, false);
        }
    }
}