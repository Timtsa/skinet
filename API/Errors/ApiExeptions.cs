namespace API.Errors
{
    public class ApiExeptions : ApiRespons
    {
        public ApiExeptions(int statusCode, string message = null, string details=null) 
        : base(statusCode, message)
        {
            Details=details;
        }

        public  string Details { get; set; }
    }
}