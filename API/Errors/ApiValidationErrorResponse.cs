using System.Collections.Generic;

namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiRespons
    {
         public IEnumerable<string> Errors { get; set; }
        public ApiValidationErrorResponse() : base(400)
        {
        }
    }
}