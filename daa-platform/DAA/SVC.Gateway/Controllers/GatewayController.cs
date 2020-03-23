using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

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
        public async Task<ActionResult> GetUsersEase()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }
    }
}
