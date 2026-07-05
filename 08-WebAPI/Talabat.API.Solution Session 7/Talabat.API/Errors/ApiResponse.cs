
namespace Talabat.API.Errors
{
    public class ApiResponse
    {
        public int StatucCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode , string? message = null)
        {
            StatucCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string? GetDefaultMessageForStatusCode(int statucCode)
        {
            return statucCode switch
            {
                400 => "A Bad Request You have Made",
                401 => "Authorized , You are not",
                404 => "Resources were not found",
                500 => "Internal Server Error!",
                _ => null
            };
        }
    }
}
