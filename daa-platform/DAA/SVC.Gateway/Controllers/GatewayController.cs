using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Services.Users;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        private readonly IUserService _userService;

        public GatewayController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("get-users")]
        public async Task<ActionResult<GetUsers.Response>> GetUsersEase([FromBody] GetUsers.Request request)
        {
            var users = await _userService.GetUsersAsync(request);
            return Ok(users);
        }
    }
}
