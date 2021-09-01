using System;

namespace API.Errors
{
    public class ApiRespons
    {
        public ApiRespons(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStausCode(statusCode) ;
        }

        private string GetDefaultMessageStausCode(int statusCode)
        {
            return statusCode switch
            {
                400=>"Bad request",
                401=>"Not authorized",
                404=>"Resourse not found",
                500=>"Server error",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
    }
}