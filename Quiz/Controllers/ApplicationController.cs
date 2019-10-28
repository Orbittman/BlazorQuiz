using Client.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : Controller
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ApplicationController(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        [HttpGet]
        public ActionResult<InitialisationResponse> Get()
        {
            var ipAddress = contextAccessor.HttpContext.Connection.RemoteIpAddress;
            return new InitialisationResponse { IpAddress = ipAddress.ToString() };
        }
    }
}