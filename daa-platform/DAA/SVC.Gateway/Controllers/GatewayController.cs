using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DAA.Platform.HttpExtensions;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Services;

namespace Gateway.Controllers
{
    [ApiController]
    [Route("gateway")]
    public class GatewayController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;
        
        public GatewayController(IUserService userService)
        {
            _userService = userService;
            _httpClient = new HttpClient();
        }

        [HttpPost("get-users-http")]
        public async Task<ActionResult> GetUsersHttp()
        {
            var response = await _httpClient.PostAsJsonAsync("http://users/users/get-users", new {});
            var users = await response.Content.ReadAsAsync<List<User>>();
            
            return Ok(users);
        }
        
        [HttpPost("get-users-ease")]
        public async Task<ActionResult> GetUsersEase()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }
    }
}
