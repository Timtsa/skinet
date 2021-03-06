using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BuggyController: ControllerBase
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
           _context = context;
        }

        [HttpGet("testauth")]
        [Authorize]
        public ActionResult<string> GetSecretKey(){
            return "secret stuff";
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing=_context.Products.Find(42);
            if(thing==null)
            return NotFound(new ApiRespons(404));

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
             var thing=_context.Products.Find(42);
             
             var thingToReturn=thing.ToString();
             return Ok();
        }



         [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiRespons(400));
        }

         [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
             return Ok();
        }

    }
}