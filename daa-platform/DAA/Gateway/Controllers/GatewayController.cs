using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        [HttpPost("get-users")]
        public ActionResult GetUsers()
        {
            return Ok();
        }
    }
}
